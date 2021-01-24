    List<String> orderBy = new List<String> { "Completed", "Business", "System" };
    
    dt = dt.AsEnumerable()
           .GroupBy(r => new {A = r["A"], C = r["C"]})
           .Select(g => g.OrderBy(r => orderBy.indexOf(r["C"]).First()))
           .CopyToDataTable();
