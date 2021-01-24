    var duplicates = db2.AsEnumerable()
      .GroupBy(r => new
      {
        Tool = r.Field<string>("Tool"),
        Product = r.Field<string>("Product"),
        Time1 = r.Field<DateTime>("Time1"),
        Row = r.Field<Int32>("Row")
      });
    foreach (var d in duplicates)
    {
      foreach (var item in d)
      {
        item.Count = d.Count();
      }
    }
