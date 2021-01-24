        public class Table
        {
            public static DataTable GetTable()
            {
                DataTable table = new DataTable();
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Date", typeof(System.DateTime));
                table.Rows.Add("cat", System.DateTime.Now);
                table.Rows.Add("dog", System.DateTime.Today);
                return table;
            }
        }
