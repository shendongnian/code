    // Assuming interestingTypes is an array or list of the interesting types
    var query = db.Whatever.Where(entry => interestingTypes.Contains(entry.Type)
                                  // I understand you're not interested in this group
                                  && !(entry.Field1==0 && entry.Field2==1));
    var grouped = query.AsEnumerable()
                       .GroupBy(entry => new { entry.Field1, entry.Field2 });
