    using (var table = adapter.GetData())
    {
        return table.Rows.Cast<DataRow>().Select(row =>
            new HouseAnnouncement()
            {
                Area = Convert.ToSingle(row[table.powierzchniaColumn]),
                City = (string)row[table.miastoColumn],
            }).ToList();
    }
