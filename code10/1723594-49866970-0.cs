    var dt3 = dt1.Clone();
    var dt4 = dt1.Clone();
    
    var matchingRows = from s1 in dt1.AsEnumerable()
                       join s2 in dt2.AsEnumerable() on s1.Field<int>("Id") equals s2.Field<int>("Id")
                       select s1;
    
    matchingRows.CopyToDataTable(dt3, LoadOption.OverwriteChanges);
    
    var nonMatchingRows = from s1 in dt1.AsEnumerable()
                          where !dt2.AsEnumerable().Any(s2 => s2.Field<int>("Id") == s1.Field<int>("Id"))
                          select s1;
    
    nonMatchingRows.CopyToDataTable(dt4, LoadOption.OverwriteChanges);
