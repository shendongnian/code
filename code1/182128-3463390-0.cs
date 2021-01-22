    private static int Zindex = 0;
    
    private void MyControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
        if(((FrameworkElement)sender).TemplatedParent==null) return;
        ContentPresenter presenter = (ContentPresenter)((FrameworkElement) sender).TemplatedParent;
    
        int currentValue = Panel.GetZIndex(presenter);
        Console.WriteLine(currentValue);
        Panel.SetZIndex(presenter, Int32.MaxValue);
    }
    
    private void MyControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
    {
        if(((FrameworkElement)sender).TemplatedParent==null) return;
        ContentPresenter presenter = (ContentPresenter)((FrameworkElement) sender).TemplatedParent;
    
        int currentValue = Panel.GetZIndex(presenter);
        Console.WriteLine(currentValue);
        Panel.SetZIndex(presenter, Zindex++);
    }
