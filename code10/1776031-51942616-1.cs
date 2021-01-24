    private void LandmarksLayer_MapElementClick(MapElementsLayer sender, MapElementsLayerClickEventArgs args)
    {
        var elements= args.MapElements;
        foreach(var item in elements)
        {
            Debug.WriteLine(item.Tag);
        }
    
        MapIcon element = args.MapElements.First<MapElement>() as MapIcon;
        Debug.WriteLine(element.Title);
    }
