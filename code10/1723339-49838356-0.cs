    private void MapUserTapped(MapControl sender, MapInputEventArgs args)
    {
        if (!edit_mode) { return; }
        //to get a basicgeoposition of wherever the user clicks on the map
        BasicGeoposition basgeo_edit_position = args.Location.Position;
        //just checking to make sure it works
        Debug.WriteLine("tapped - lat: " + basgeo_edit_position.Latitude.ToString() + "  lon: " + basgeo_edit_position.Longitude.ToString());
        EditMapIconPosition(basgeo_edit_position);
    }
