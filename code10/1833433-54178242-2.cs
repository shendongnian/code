    var T1 = new string[] {
        "1,2,3,4,5", // Dupe                
        "2,2",
        "4,5,6,7,8", // Uniq
    };
    var T2 = new string[] {
        "1,2,3,4,5", // Dupe
        "2,2,2",
        "42", // Uniq
    };
    // 
    DataTable dataTable1 = new DataTable();
    using (var reader = ObjectReader.Create(T1.Select(x => new { columnOne = x })))
    {
        dataTable1.Load(reader);
    }
    DataTable dataTable2 = new DataTable();
    using (var reader = ObjectReader.Create(T2.Select(x => new { columnOne = x })))
    {
        dataTable2.Load(reader);
    }
