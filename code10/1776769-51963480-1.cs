    var testQuery = (
                from b_TestTable in repos.GetTable<TestTable>() 
                where b_TestTable.Date.Month == dat.Month && b_TestTable.Date.Year = dat.Month
                select b_TestTable.TestingValues)
            .ToArray();
