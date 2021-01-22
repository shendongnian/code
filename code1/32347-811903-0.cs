    from t in SomeTable
    group t by new { t.Field1 } into g
    orderby g.Key.Field1
    select new
    { 
      g.Key.Field1,
      code = g.Min(c => c.Field2),
      qty = g.Count()
    }
