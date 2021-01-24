    private void MyMapControl_MapElementClick(MapControl sender, MapElementClickEventArgs args)
    {
        var elements = args.MapElements;
        foreach (var item in elements)
        {
            Debug.WriteLine(item.Tag);
        }
    
        MapIcon element = args.MapElements.First<MapElement>() as MapIcon;
        Debug.WriteLine(element.Title);
    }
