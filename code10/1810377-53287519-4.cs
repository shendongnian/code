    var duplicates = db2.AsEnumerable()
      .GroupBy(r => new
      {
        Tool = r.Field<string>("Tool"),
        Product = r.Field<string>("Product"),
        Time1 = r.Field<DateTime>("Time1"),
        Row = r.Field<Int32>("Row")
      });
    foreach (var d in duplicates)  //Iterate through the groups
    {
      foreach (var item in d)  //Iterate through the items in a group
      {
        item.Count = d.Count();
      }
    }
