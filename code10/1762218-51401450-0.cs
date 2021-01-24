    public void AddSpaceNeedleIcon()
    {
        var MyLandmarks = new List<MapElement>();
    
        BasicGeoposition snPosition = new BasicGeoposition { Latitude = 47.620, Longitude = -122.349 };
        Geopoint snPoint = new Geopoint(snPosition);
    
        var spaceNeedleIcon = new MapIcon
        {
            Location = snPoint,
            NormalizedAnchorPoint = new Point(0.5, 1.0),
            ZIndex = 0,
            Title = "Space Needle"
        };
    
        MyLandmarks.Add(spaceNeedleIcon);
    
        var LandmarksLayer = new MapElementsLayer
        {
            ZIndex = 1,
            MapElements = MyLandmarks
        };
    
        myMap.Layers.Add(LandmarksLayer);
    
        myMap.Center = snPoint;
        myMap.ZoomLevel = 14;
    
    }
