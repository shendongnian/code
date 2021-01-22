    var location = new GeoLocationDC();
    var ds = db.ExecuteDataSet(dbCommand);
    if(ds.Tables[0].Rows.Count == 1)
    {
        var row = ds.Tables[0].AsEnumerable().Single();
        location = new GeoLocationDC
        {
            Latitude = row.Field<int>("LATITUDE"),
            Longitude = row.Field<int>("LONGITUDE"),
        };
    }
