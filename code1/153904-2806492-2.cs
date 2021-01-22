    MapLayer m_PushpinLayer = new MapLayer(); 
    Your_Map.Children.Add(m_PushpinLayer);
    Image image = new Image(); 
    image.Source = ResourceFile.GetBitmap("Images/Pushpin.png", From.This); 
    TextBlock textBlock = new TextBlock();
    textBlock.Text = "My Pushpin";
    Grid grid = new Grid();
    grid.Children.Add(image);
    grid.Children.Add(textBlock);
    
    m_PushpinLayer.AddChild(grid, 
        new Microsoft.Maps.MapControl.Location(42.658, -71.137),   
            PositionOrigin.Center);
 
