    // List of Duplicate
    var dupes =
       dataTable1
           .AsEnumerable()
           .Where(r1 =>
                dataTable2
                   .AsEnumerable()
                   .Any(r2 =>
                       {
                           var c1 = r1.Field<string>(0);
                           var c2 = r2.Field<string>(0);
                           var splitC1 = c1.Split(',').Select(x => x.Trim()).ToList();
                           var splitC2 = c2.Split(',').Select(x => x.Trim()).ToList();
                           return true
                                  && (splitC1.Count() == splitC2.Count())
                                  && !splitC1.Except(splitC2).Any();
                       }
                    )
            );
