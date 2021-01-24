    var testQuery = (
        from b_TestTable in repos.GetTable<TestTable>() 
        where b_TestTable.Date.Year == dats.Year && b_TestTable.Date.Month == dats.Month
        select b_TestTable.TestingValues)
    .ToArray();
