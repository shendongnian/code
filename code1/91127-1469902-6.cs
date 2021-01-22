    var tableARows = Context.TableB.Include("TableA")
                            .Where(b => b.TableBID == 1)
                            .Single()
                            .TableA.OrderBy(a => a.ColumnToSort)
                            .ToList();
