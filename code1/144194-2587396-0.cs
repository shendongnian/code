    var table = adapter.GetData();
    
    IList<IHouseAnnouncement> list = table.Rows.Cast<DataRow>().Select(row =>
        new HouseAnnouncement()
        {
            Area = float.Parse(row["powierzchnia"].ToString()),
            City = row["miasto"].ToString()
        }).ToList();
