    public string GetStatisticsForChart(string messageCode)
    {
        //some repository that returns data....
        var data = _statisticsRepository.GetPerMessage(messageCode);
        //It simply returns a list of objects with Year and Count properties.
        var query = (from t in data
                    group t by new {t.TimeStamp.Year}
                    into grp
                    select new
                        {
                            grp.Key.Year,
                            Count = grp.Count()
                        }).ToList();
        //let's instantiate the DataTable.
        var dt = new Google.DataTable.Net.Wrapper.DataTable();
        dt.AddColumn(new Column(ColumnType.String, "Year", "Year"));
        dt.AddColumn(new Column(ColumnType.Number, "Count", "Count"));
        foreach (var item in query)
        {
            Row r = dt.NewRow();
            r.AddCellRange(new Cell[]
            {
                new Cell(item.Year),
                new Cell(item.Count)
            });
            dt.AddRow(r);
        }
           
    //Let's create a Json string as expected by the Google Charts API.
    return dt.GetJson();
    }
