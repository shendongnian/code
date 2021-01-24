    var newDt = dt.AsEnumerable()
                  .GroupBy(r => r.Field<string>("BATCH NUM"))
                  .Select(g =>
                  {
                      var row = dt.NewRow();
    
                      row["BATCH NUM"] = g.Key;
                      row["QTY"] = g.Sum(r => Convert.ToInt32(r.Field<string>("QTY")) + Convert.ToInt32(r.Field<string>("BONUS")));
                      row["PROD ID"] = String.Join(",", g.Select(x => x.Field<string>("PROD ID")).Distinct());
                      return row;
                  }).CopyToDataTable();
