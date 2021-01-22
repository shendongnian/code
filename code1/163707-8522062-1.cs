    var grid = new Grid();            
    int timestamp = new TimeSpan(DateTime.Now.Ticks).Milliseconds;
    const MouseButton mouseButton = MouseButton.Left;
    var mouseDownEvent =
       new MouseButtonEventArgs(Mouse.PrimaryDevice, timestamp, mouseButton) {
           RoutedEvent = UIElement.MouseLeftButtonDownEvent,
           Source = grid,
       };
