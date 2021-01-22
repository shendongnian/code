    var popup = new Popup
    {
        Child = new YourUIControlHere(),
        Placement = PlacementMode.Center,
        PlacementRectangle = new Rect(new Size(
            SystemParameters.FullPrimaryScreenWidth, 
            SystemParameters.FullPrimaryScreenHeight))
    };
