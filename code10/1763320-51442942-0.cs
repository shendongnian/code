    var newDt = dt.AsEnumerable()
    .ToLookup(r => r.Field<string>("PROD ID"))
    .Select(g =>
    {
         var row = dt.NewRow();
         row["PROD ID"] = g.Key;
         row["QTY"] = g.Sum(r => Convert.ToInt32(r.Field<string>("QTY")) + Convert.ToInt32(r.Field<string>("BONUS")));
         row["BATCH NUM"] = String.Join(",", g.Select(x => x.Field<string>("BATCH NUM")));
         return row;
    }).CopyToDataTable();
