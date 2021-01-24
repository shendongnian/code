    var jointList = totalDaysInDateRange.Join(
                            AssignersList,
                            p => p,
                            c => c.Date,
                            (p, c) => new { c.AssignerName, c.Date }
                        ).Distinct().GroupBy(x => x.AssignerName).Select(group => 
                            new { 
                                 AssignerName = group.Key, 
                                 Count = group.Count() 
                            }).ToList();
