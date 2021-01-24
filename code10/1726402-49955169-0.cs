    var result1 = (
         from p in result
         group p by new
         {
             p.idPoiType,
         } into g
         select new RootPoints()
         {
             idPoiType = g.Key.idPoiType,
             point = (from p2 in g
                      select new ChildPoints()
                      {
                          latPoint = p2.latPoint,
                          lngPoint = p2.lngPoint
                      }).ToList() // << here
         }
         ).ToList();
