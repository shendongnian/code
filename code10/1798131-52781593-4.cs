    if (dt.Rows.Count > 0)
    {
        dt = dt.AsEnumerable().OrderByDescending(x=>x.Field<decimal>("Hotel Costs")).ThenByDescending(x=>x.Field<decimal>("Flight Costs"))
        .Select(x=>x)
        .CopyToDataTable();
    }
