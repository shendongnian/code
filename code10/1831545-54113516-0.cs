                List<string> rank = new List<string>() { "Gold", "Bronze","Silver" };
     
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Priority", typeof(string));
                dt.Rows.Add(new object[] { 9, "Steve", "Silver" });
                dt.Rows.Add(new object[] { 8, "Max", "Silver" });
                dt.Rows.Add(new object[] { 7, "Peter", "Silver" });
                dt.Rows.Add(new object[] { 6, "Josh", "Silver" });
                dt.Rows.Add(new object[] { 5, "Jack", "Bronze" });
                dt.Rows.Add(new object[] { 4, "Adam", "Bronze" });
                dt.Rows.Add(new object[] { 3, "David", "Gold" });
                dt.Rows.Add(new object[] { 1, "Bob", "Gold" });
                dt.Rows.Add(new object[] { 2, "Rob", "Gold" });
               DataRow[] results = dt.AsEnumerable().OrderBy(x => rank.IndexOf(x.Field<string>("Priority"))).Take(5).ToArray();
