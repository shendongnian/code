    void OnTouchEffectAction(object sender, TouchActionEventArgs args)
    {
     		if (args.Type != TouchActionType.Pressed)
     		{
     			return;
     		}
    
     		var pointLocation = args.Location;
            var point =
                new SKPoint((float)(canvasView.CanvasSize.Width * pointLocation.X / canvasView.Width),
                            (float)(canvasView.CanvasSize.Height * pointLocation.Y / canvasView.Height));
    
        	// TODO: Handle your touch here
    }
