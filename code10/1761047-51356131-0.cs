                 data.GroupBy(o => new { X = o.X, Y = o.Y })
                    .Select(g => new
                    {
                        Items = g.Select(gp => new WayPoint
                            {
                                MPID = gp.MPID,
                                MAPPOINT = gp.MAPPOINT,
                                X = g.Key.X,
                                Y = g.Key.Y,
                                MPCODE = gp.MPCODE,
                                MultipleSite = g.Count() > 1
                            })
                    }
                  )
                  .SelectMany(g=>g.Items)
                  .ToList();
