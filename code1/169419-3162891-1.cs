    public void PopupAnimation(UIElement element)
	{
		double w = element.RenderSize.Width,h = element.RenderSize.Height;
		var screen = new Canvas();
		var pos = element.PointToScreen(new Point(0, 0));
		var rtb = new RenderTargetBitmap((int)w,(int)h, 96, 96, PixelFormats.Pbgra32);
		rtb.Render(element);
		Image i = new Image { Source = rtb, Width = w, Height = h,Stretch=Stretch.Fill};
		Canvas.SetLeft(i, pos.X);
		Canvas.SetTop(i, pos.Y);
		screen.Children.Add(i);
		var window = new Window() {
			Content = screen, AllowsTransparency = true,
			Width=SystemParameters.PrimaryScreenWidth,Height=SystemParameters.PrimaryScreenHeight,
			WindowStyle=WindowStyle.None,ShowInTaskbar=false,Topmost=true,
			Background=Brushes.Transparent,ShowActivated=false,Left=0,Top=0
		};
		var transform = new RotateTransform();
		i.RenderTransformOrigin = new Point(0.5, 0.5);
		i.RenderTransform = transform;
		var anim = new DoubleAnimation { To = 360 };
		anim.Completed += (s,e) => 
		{
			element.Visibility = Visibility.Visible;
			var delay = new Storyboard { Duration = TimeSpan.FromSeconds(0.1) };
			delay.Completed += (s2, e2) => window.Close();
			delay.Begin();
		};
		window.ContentRendered += (s, e) =>
		{
			transform.BeginAnimation(RotateTransform.AngleProperty, anim);
			element.Visibility = Visibility.Hidden;
		};
		window.Show();
	}
