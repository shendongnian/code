    private async Task<ZonePolygon> CreateZonedPolygonAsync(Zone zone)
    {
        int StatusSys = zone.StatusSys;
        var status = await App.Database.GetStatusBySysAsync(StatusSys);
        int OutStatusSys = zone.OutOfZoneStatusSys;
        var outStatus = await App.Database.GetStatusBySysAsync(OutStatusSys);
        var points = await App.Database.GetZonePointsAsync(zone.ZoneSys);
            
            
        ZonePolygon zonePolygon = new ZonePolygon
        {
            ID = zone.ID
        };
        TKPolygon poly = new TKPolygon();
        foreach (Model.Point point in points)
        {
            poly.Coordinates.Add(new Position(point.Latitude, point.Longitude));
        }
        poly.Color = Color.FromHex(status.ColorCode);
        poly.StrokeColor = Color.Firebrick;
        poly.StrokeWidth = 5f;
        zonePolygon.Zpolygon = poly;
        _polygons.Add(poly);
        
        ZonePolygons.Add(zonePolygon);
        return zonePolygon;  
    }
