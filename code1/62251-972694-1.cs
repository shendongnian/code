    void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Point p = e.GetPosition(null);
        var elements =  VisualTreeHelper.FindElementsInHostCoordinates(p, App.Current.RootVisual);
        foreach (var element in elements)
        {
            //Figure out if you're over a particular UI element
        }
    }
