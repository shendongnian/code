    var p2 = p1.AsEnumerable()
               .SelectMany(pg => pg.Punches.Select((p, i) => (p, i))
                                           .GroupBy(pi => pi.i / 2, pi => pi.p)
                                           .Select(pp => new {
                                                pg.Badge,
                                                TimeIn = pp.Where(p => p.Dir == "IN").FirstOrDefault()?.Time,
                                                TimeOut = pp.Where(p => p.Dir == "OUT").FirstOrDefault()?.Time
                                           }));
