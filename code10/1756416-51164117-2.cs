    var p2 = p1.AsEnumerable()
               .SelectMany(pg => pg.Punches.Select((p, i) => new { pg.Badge, p, i })
                                           .GroupBy(pi => pi.i / 2)
                                           .Select(pip => new {
                                                pip.First().Badge,
                                                TimeIn = pip.Where(pi => pi.p.Dir == "IN").FirstOrDefault()?.p.Time,
                                                TimeOut = pip.Where(pi => pi.p.Dir == "OUT").FirstOrDefault()?.p.Time
                                           }));
