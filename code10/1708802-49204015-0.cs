    var regrouped = grouped.SelectMany(cg => cg.GroupBy(i => i.Priority)
                                               .ToLookup(pg => new { Color = cg.Key, Priority = pg.Key },
                                                         pg => pg.Select(i => i)
                                                        )
                                      );
