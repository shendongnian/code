    private void Map_MapTapped(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapInputEventArgs args)
    {
        var GeoPosition = args.Location.Position;
        string status = "MapTapped at \nLatitude:" + GeoPosition.Latitude + "\nLongitude: " + GeoPosition.Longitude;
        rootPage.NotifyUser( status, NotifyType.StatusMessage);
    }
