	void PanUpdated(object sender, PanUpdatedEventArgs args)
	{
		if (args.StatusType.Equals(GestureStatus.Running)) {
			x = args.TotalX;
			y = args.TotalY;
			image.TranslateTo(x, y, 1);
		}
		else if (args.StatusType.Equals(GestureStatus.Completed)) {
			// set the layout bounds of the image to the new position
			// method varies depending on what type of layout you are using for the image
			// eg. assume the image is in an absolute layout
			// where the layout height is the screen height
			// and the layout width is the screen width
			
			Task.Run(() => {
				Device.BeginInvokeOnMainThread(async () => // run UI task on main thread
				{
					await Task.Delay(50); // avoid flickering
					var screenWidth = Application.Current.MainPage.Width;
					var screenHeight = Application.Current.MainPage.Height;
					var b = image.Bounds;
					var newBounds = new Rectangle(b.X + x, b.Y + y, b.Width, b.Height);
					var newAbsoluteBound =
						new Rectangle(newBounds.X / (screenWidth - newBounds.Width),
									  newBounds.Y / (screenHeight - newBounds.Height),
									  newBounds.Width / screenWidth,
									  newBounds.Height / screenHeight);
					// set new absolute bounds so a new TranslateTo can be applied
					AbsoluteLayout.SetLayoutBounds(image, newAbsoluteBound);
					await image.TranslateTo(0, 0, 0);
				});
			});				 
		}
	}
