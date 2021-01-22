    void CanvasLayout_PreviewMouseLeftButtonDown(object s, MouseButtonEventArgs e)
    {
        if (e.ClickCount > 1)
        {
            // Do double-click code  
            // Code for FullScreen 
            e.Handled = true;
        }
    }
