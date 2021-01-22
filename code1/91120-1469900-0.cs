    var tablearows = Context.TableB.Include("TableB")
         .Where(c => c.TableBID == 1)
         .SelectMany(c => c.TableA)
         .OrderBy(p => p.ColumnToSort)
         .ToList();
