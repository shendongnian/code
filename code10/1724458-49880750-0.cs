                DataTable dt = new DataTable();
                dt.Columns.Add("Key", typeof(string));
                dt.Columns.Add("Group", typeof(int));
                dt.Columns.Add("Count", typeof(int));
                dt.Rows.Add(new object[] {"A", 1,2});
                dt.Rows.Add(new object[] {"A", 2,2});
                dt.Rows.Add(new object[] {"A", 3,2});
                dt.Rows.Add(new object[] {"B", 1,3});
                dt.Rows.Add(new object[] {"B", 2,3});
                dt.Rows.Add(new object[] {"B", 3,2});
                dt.Rows.Add(new object[] {"C", 1,1});
                dt.Rows.Add(new object[] {"C", 3,1});
                var groups = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Key")).Select(x => x.GroupBy(y => y.Field<int>("Count")).ToList()).ToList();
