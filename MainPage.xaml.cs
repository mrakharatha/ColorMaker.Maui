using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
	private bool _isRandom = false;
	private string _hexValue="#000000";
	public MainPage()
	{
		InitializeComponent();
	}


	private void Sld_OnValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (_isRandom)
			return;

		var red = SldRed.Value;
		var green = SldGreen.Value;
		var blue = SldBlue.Value;

		var color = Color.FromRgb(red, green, blue);
		SetColor(color);
	}

	private void SetColor(Color color)
	{
		Container.BackgroundColor = color;
		BtnRandom.BackgroundColor = color;
		_hexValue = color.ToHex();
		LblHex.Text = $"Hex Value : {_hexValue}";
	}


	private async void ImageButton_OnClicked(object sender, EventArgs e)
	{
		await Clipboard.SetTextAsync(_hexValue);
		var toast = Toast.Make("Color Copied",ToastDuration.Short,13);
		await toast.Show();
	}

	private void BtnRandom_OnClicked(object sender, EventArgs e)
	{
		_isRandom = true;
		var random = new Random();

		var red = random.Next(0, 256);
		var green = random.Next(0, 256);
		var blue = random.Next(0, 256);

		var color = Color.FromRgb(red, green, blue);

		SldRed.Value = color.Red;
		SldGreen.Value = color.Green;
		SldBlue.Value = color.Blue;

		SetColor(color);
		_isRandom = false;
	}
}

