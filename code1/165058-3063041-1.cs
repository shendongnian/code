    var location = new GeoLocationDC();
    var ds = db.ExecuteDataSet(dbCommand);
    if(ds.Tables[0].Rows.Count == 1)
    {
        var row = ds.Tables[0].AsEnumerable().Single();
        location.Latitude = row.Field<int>("LATITUDE");
        location.Longitude = row.Field<int>("LONGITUDE");
    }
