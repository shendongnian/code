        Image img = new Image();
        img.Height = 100;
        img.Width = 100;
        img.Source = new BitmapImage(new Uri("ms-appx:///Assets/YourBitmapName.jpg"));
        MapControl.SetNormalizedAnchorPoint(img, new Point(0.5, 0.5));
        MapControl.SetLocation(img, new Geopoint(new BasicGeoposition() { Latitude = 47, Longitude = -122, Altitude = 0 }, AltitudeReferenceSystem.Terrain));
        yourMapControlInstanceName.Children.Add(img);
