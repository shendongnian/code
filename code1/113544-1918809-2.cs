    var bazGroups =
        (from t1 in things
         group t1 by t1.Foo into gFoo
         select new
         {
             Key = gFoo.Key,
             Value = (from t2 in gFoo
                      group t2 by t2.Bar into gBar
                      select gBar)
                      .ToDictionary(g => g.Key, g => g.First().Baz)
         })
         .ToDictionary(g => g.Key, g => g.Value);
