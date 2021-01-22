    mySlider.PreviewMouseMove += (sender, args) =>
    {
        if (args.LeftButton == MouseButtonState.Pressed)
        {
            mySlider.RaiseEvent(new MouseButtonEventArgs(args.MouseDevice, args.Timestamp, MouseButton.Left)
            {
                RoutedEvent = UIElement.PreviewMouseLeftButtonDownEvent,
                     Source = args.Source
            });
        }
    };
