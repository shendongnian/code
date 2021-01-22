    var query = 
        from d in MyContext.MyTable
        let v1 = MyContext.MyTable.Where(dd => dd.ID == d.ID).Select(dd => dd.Value1)
        let v2 = MyContext.MyTable.Where(dd => dd.ID == d.ID).Select(dd => dd.Value2)
        // ...
        let v6 = MyContext.MyTable.Where(dd => dd.ID == d.ID).Select(dd => dd.Value6)
        from n in v1.Concat(v2).Concat(v3).Concat(v4).Concat(v5).Concat(v6)
        group 1 by n into g
        orderby g.Key
        select new
        {
            number = g.Key,
            Occureneces = g.Count(),
        };
