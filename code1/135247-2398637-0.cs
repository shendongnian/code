                var myTable1 = new [] { 
                new { CID = "123", AID = 345, Data = 32323, Status = 1, Language = "EN"},
                new { CID = "231", AID = 123, Data = 11525, Status = 2, Language = "EN"},
                new { CID = "729", AID = 513, Data = 15121, Status = 1, Language = "ANY"},
                new { CID = "231", AID = 123, Data = 54421, Status = 2, Language = "EN"}}
                .ToDataTable().AsEnumerable();
            
            var myTable2 = new [] { 
                new { CID = "512", AID = 513, Data = 32323, Status = 1, Language = "ANY"},
                new { CID = "444", AID = 123, Data = 11525, Status = 2, Language = "BLAH"},
                new { CID = "222", AID = 333, Data = 15121, Status = 1, Language = "ANY"},
                new { CID = "111", AID = 345, Data = 54421, Status = 2, Language = "EN"}}
                .ToDataTable().AsEnumerable();
             var myTable3 = new [] { 
                new { CID = "888", AID = 123, Data = 32323, Status = 2, Language = "EN"},
                new { CID = "494", AID = 333, Data = 11525, Status = 1, Language = "FR"},
                new { CID = "202", AID = 513, Data = 15121, Status = 1, Language = "EN"},
                new { CID = "101", AID = 345, Data = 54421, Status = 2, Language = "ANY"}}
                .ToDataTable().AsEnumerable();
             var q = from p in myTable1
                     join b in myTable2.Union(myTable3) on p.Field<int>("AID") equals b.Field<int>("AID")
                     where (b.Field<string>("Language") == "EN" || b.Field<string>("Language") == "ANY") && b.Field<int>("Status") == 1
                     select new
                     {
                         CID = p.Field<string>("CID"),
                         B_AID = p.Field<int>("AID"),
                         P_AID = b.Field<int>("AID"),
                         Data = b.Field<int>("Data"),
                         Status = b.Field<int>("Status"),
                         Language = b.Field<string>("Language")
                     };
             var table = q.ToDataTable();
