    private void MyMap_Loaded(object sender, RoutedEventArgs e)
    {
        // Specify a known location.
        BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
        Geopoint snPoint = new Geopoint(snPosition);
    
        // Create a XAML border.
        var ellipse1 = new Ellipse();
        ellipse1.Fill = new SolidColorBrush(Windows.UI.Colors.Coral);
        ellipse1.Width = 200;
        ellipse1.Height = 200;
    
        // Center the map over the POI.
        MyMap.Center = snPoint;
        MyMap.ZoomLevel = 14;
    
        // Add XAML to the map.
        MyMap.Children.Add(ellipse1);
        MapControl.SetLocation(ellipse1, snPoint);
        MapControl.SetNormalizedAnchorPoint(ellipse1, new Point(0.5, 0.5));
    }
