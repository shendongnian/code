    var groups = table
        .AsEnumerable()
        .GroupBy(row => row.Field<int>("ID"))
        .Select(grp => new { Id = grp.Key, Values = grp.Select(r => r.Field<int>("HValue")) });
        
    foreach(var group in groups)
    {
        int id = group.Id;
        IEnumerable<int> values = group.Values;
    }
