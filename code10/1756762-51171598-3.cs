		var JoinedResult = (from t1 in table1.Rows.Cast<DataRow>()
                   join t2 in table2.Rows.Cast<DataRow>() 
                   on Convert.ToInt32(t1.Field<string>("ProductID")) equals t2.Field<int>("FuelId")
                   select new { T1 = t1,
                                T2 = t2.column_name // all columns needed can be listed here
                              }).ToList();
