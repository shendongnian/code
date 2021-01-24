    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        RouteViewer Rv = new RouteViewer(((sender as Button).Tag).ToString());
        Rv.Show();
       
        var newEventArgs = new RoutedEventArgs(RvOpenedEvent);
        RaiseEvent(newEventArgs);
    }
        
        
        
    public static readonly RoutedEvent RvOpenedEvent = EventManager.RegisterRoutedEvent(
        "RvOpened",
        RoutingStrategy.Bubble, 
        typeof(RoutedEventHandler), 
        typeof(ClassName)); 
        
    public event RoutedEventHandler RvOpened
    {
        add { AddHandler(RvOpenedEvent, value); }
        remove { RemoveHandler(RvOpenedEvent, value); }
    }
