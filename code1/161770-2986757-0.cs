    void Window_Loaded(object sender, RoutedEventArgs e)
    {
        // ...
        button1.PreviewMouseLeftButtonDown += Button1_PreviewMouseLeftButtonDown;
        button1.PreviewMouseLeftButtonUp += Button1_PreviewMouseLeftButtonUp;
    }
        
    void Button1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Mouse.OverrideCursor = Cursors.Cross;
        Mouse.Capture(button1);
    }
    
    void Button1_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        Mouse.Capture(null);
        Mouse.OverrideCursor = null;
    }
