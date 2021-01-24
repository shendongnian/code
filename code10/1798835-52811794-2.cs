	button.Clicked += async (object sender, EventArgs e) =>
	{
		var contentView = new WarningPopup();
		someContainer.Children.Add(contentView);
		await Task.Delay(1000);
		someContainer.Children.Remove(contentView);
	};
