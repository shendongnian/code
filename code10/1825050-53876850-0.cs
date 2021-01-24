    var final = (from studData in dtS.AsEnumerable()
                     join table2 in DataDT.AsEnumerable() on studData[1] equals table2[0] into part1
                     from p1 in part1.DefaultIfEmpty()
                     join table3 in DataDT2.AsEnumerable() on studData[1] equals table3.Field<string>(0) into part2
                     from p2 in part2.DefaultIfEmpty()
                     join table4 in DataDT3.AsEnumerable() on studData[1] equals table4.Field<string>(0) into part3
                     from p3 in part3.DefaultIfEmpty()
                     select new Model
                     {
                         TestID = table1.Field<int>(0),
                         ID = table1.Field<string>(1),
                         Name = table1.Field<string>(2),
                         Absent = table1.Field<bool>(3),
                         Gender = table1.Field<string>(4),
                         Grade = table1.Field<int>(5),
                         TestDate = table1.Field<string>(7),
                         SessionNumber = table1.Field<int>(8),
                         Room = table1.Field<string>(9),
                         Code = table1.Field<string>(10),
                         Booklet = table1.Field<string>(11),
                         Color = (p3 == null) ? "" : p3[1],
                         Accomm = (p2 == null) ? "" : p2[1],
                         SID = (p1 == null) ? "" : p1[1],
                         LocalName = (p1 == null) ? "" : p1[2],
                     }).ToList();
