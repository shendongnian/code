	public MainPage()
	{
		var labelTappedGestureRecognizer = new TapGestureRecognizer
		{
			Command = new Command<string>(async labelText => await DisplayAlert("Label Tapped", labelText, "OK"))
		};
		var myLabel = new Label
		{
			Text = "This is my label",
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center
		};
		myLabel.GestureRecognizers.Add(labelTappedGestureRecognizer);
		labelTappedGestureRecognizer.SetBinding(TapGestureRecognizer.CommandParameterProperty, new Binding(nameof(Label.Text), source: myLabel));
		Content = myLabel;
	}
