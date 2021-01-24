    (IDbConnection) conn.Query("SELECT Production, Workstation FROM product").AsList()
            .GroupBy(o -> o.Cell)
            .Select(g-> new Workstation {
              Cell = g.Key,
              Productions = g.Select(x=>new Production { product_name = x.Production }).ToList()
            })
            .ToList();
