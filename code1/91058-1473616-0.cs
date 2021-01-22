    int days = 30;
    
    // Gather the data we have in the database, which will be incomplete for the graph (i.e. missing dates/subsystems).
    var dataQuery =
        from tr in SourceDataTable
        where (DateTime.UtcNow - tr.CreatedTime).Days < 30
        group tr by new { tr.CreatedTime.Date, tr.Subsystem } into g
        orderby g.Key.Date ascending, g.Key.SubSystem ascending
        select new MyResults()
        {
            Date = g.Key.Date, 
            SubSystem = g.Key.SubSystem,
            Count = g.Count()
        };
    
    // Generate the list of subsystems we want.
    var subsystems = new[] { SubSystem.Foo, SubSystem.Bar }.AsQueryable();
    
    // Generate the list of Dates we want.
    var datetimes = new List<DateTime>();
    for (int i = 0; i < days; i++)
    {
        datetimes.Add(DateTime.UtcNow.AddDays(-i).Date);
    }
    
    // Generate the empty table, which is the shape of the output we want but without counts.
    var emptyTableQuery =
        from dt in datetimes
        from subsys in subsystems
        select new MyResults()
        {
            Date = dt.Date, 
            SubSystem = subsys,
            Count = 0
        };
    
    // Perform an outer join of the empty table with the real data and use the magic DefaultIfEmpty
    // to handle the "there's no data from the database case".
    var finalQuery =
        from e in emptyTableQuery
        join realData in dataQuery on 
            new { e.Date, e.SubSystem } equals 
            new { realData.Date, realData.SubSystem } into g
        from realDataJoin in g.DefaultIfEmpty()
        select new MyResults()
        {
            Date = e.Date,
            SubSystem = e.SubSystem,
            Count = realDataJoin == null ? 0 : realDataJoin.Count
        };
    
    return finalQuery.OrderBy(x => x.Date).AsEnumerable();
