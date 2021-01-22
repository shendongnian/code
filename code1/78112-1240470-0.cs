    /* // This all works
                 IQueryable<QueryData> queryDataIDs = new QueryData[]{ 
                    new QueryData{DataEventKeyID = 1, ValueDecimal = 2.2m },
                    new QueryData{DataEventKeyID = 2, ValueDecimal = 2.3m },
                    new QueryData{DataEventKeyID = 3, ValueDecimal = 2.4m },
                    new QueryData{DataEventKeyID = 4, ValueDecimal = 2.5m },
                    new QueryData{DataEventKeyID = 5, ValueDecimal = 2.6m },
                    new QueryData{DataEventKeyID = 6, ValueDecimal = 2.7m },
                    new QueryData{DataEventKeyID = 7, ValueDecimal = 2.8m },
                    new QueryData{DataEventKeyID = 8, ValueDecimal = 2.9m }
                }.AsQueryable();
    
                // some local collection of ids 
                var terminalID = new List<int>(){1, 2, 3, 4, 5};
    
                // a part of a Linq statement: 
                var selectedValues = queryDataIDs
                    .Where(q => q.DataEventKeyID == 2)
                    .Where(q => terminalID.Contains((int)q.ValueDecimal)); */
    
                TestQueryDataDataContext db = new TestQueryDataDataContext();
                IQueryable<TestQueryData> queryDataIDs = db.TestQueryDatas;
                var terminalID = new List<int>() { 1, 2, 3, 4, 5 };
                var selectedValues = queryDataIDs
                    .Where(q => q.DataEventKeyID == 2)
                    .Where(q => terminalID.Contains((int)q.ValueDecimal));
