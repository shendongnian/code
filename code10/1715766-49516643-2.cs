	void PanUpdated(object sender, PanUpdatedEventArgs args)
	{
		if (args.StatusType.Equals(GestureStatus.Running))
		{
			var x = args.TotalX;
			var y = args.TotalY;
			image.TranslateTo(x, y, 1);
		}
		
		if (args.StatusType.Equals(GestureStatus.Completed)) {
			// set the layout bounds of the image to the new position
			// method varies depending on what type of layout you are using for the image
		}
	}
