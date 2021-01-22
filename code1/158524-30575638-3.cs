    mySlider.MouseMove += (sender, args) =>
    {
        if (args.LeftButton == MouseButtonState.Pressed && this.clickedInSlider)
        {
            var thumb = (mySlider.Template.FindName("PART_Track", mySlider) as System.Windows.Controls.Primitives.Track).Thumb;
            thumb.RaiseEvent(new MouseButtonEventArgs(args.MouseDevice, args.Timestamp, MouseButton.Left)
            {
                RoutedEvent = UIElement.MouseLeftButtonDownEvent,
                     Source = args.Source
            });
        }
    };
    mySlider.AddHandler(UIElement.PreviewMouseLeftButtonDownEvent, new RoutedEventHandler((sender, args) =>
    {
        clickedInSlider = true;
    }), true);
    mySlider.AddHandler(UIElement.PreviewMouseLeftButtonUpEvent, new RoutedEventHandler((sender, args) =>
    {
        clickedInSlider = false;
    }), true);
