	private async void Button_Clicked(object sender, EventArgs e)
	{
		uint transitionTime = 600;
		double displacement = image.Width;
		await Task.WhenAll(
			image.FadeTo(0, transitionTime, Easing.Linear),
			image.TranslateTo(-displacement, image.Y, transitionTime, Easing.CubicInOut));
		
		// Changes image source.
		image.Source = ImageSource.FromFile("Icon");
		await image.TranslateTo(displacement, 0, 0);
		await Task.WhenAll(
			image.FadeTo(1, transitionTime, Easing.Linear),
			image.TranslateTo(0, image.Y, transitionTime, Easing.CubicInOut));
	}
