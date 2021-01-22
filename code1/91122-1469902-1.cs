    var tablearows = Context.TableB.Include("TableB")
                            .Where(c => c.TableBID == 1)
                            .Select(c => c.TableA)
                            .OrderBy(p => p.ColumnToSort)
                            .ToList();
