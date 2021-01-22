    public TrafficTotals CalculateTotals(DataTable table, 
                                         Func<DataRow, bool> filter)
    {
        TrafficTotals total = new TrafficTotals();
        total.TotalTraffic = table.AsEnumerable()
                                  .Where(filter)
                                  .Sum(p => p.Field<int>("Converted"));
        // More stuff
    }
