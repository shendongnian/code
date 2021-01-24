	// create a grid and bind it to the parent window's size
	var grid = new Grid { Background = Brushes.CornflowerBlue };    // <- sets background color
	grid.SetBinding(WidthProperty, new Binding
	{
		RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1),
		Path = new PropertyPath("ActualWidth"),
		Mode = BindingMode.OneWay,
		UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
	});
	grid.SetBinding(HeightProperty, new Binding
	{
		RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Window), 1),
		Path = new PropertyPath("ActualHeight"),
		Mode = BindingMode.OneWay,
		UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
	});
	// add the media player
	grid.Children.Add(new MediaElement
	{
		Source = new Uri("yourvideo.mp4", UriKind.RelativeOrAbsolute),
		LoadedBehavior = MediaState.Play,
		Stretch = Stretch.Fill,
		HorizontalAlignment = HorizontalAlignment.Center,
		VerticalAlignment = VerticalAlignment.Center,
		Width = 640,	// <-- video size
		Height = 480
	});
	// wrap it all up in a visual brush
	this.Background = new VisualBrush { Visual = grid };
