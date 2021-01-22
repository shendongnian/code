    var byColumn = 3;
    var rows = new List<object[]> 
    { 
        new object[] {1, "test1", "foo", 1}, 
        new object[] {1, "test1", "foo", 2}, 
        new object[] {2, "test1", "foo", 3}, 
        new object[] {2, "test2", "foo", 4}, 
    };
    var grouped = rows.GroupBy(k => k[byColumn]);
    var otherGrouped = rows.GroupBy(k => new { k1 = k[1], k2 = k[2] });
