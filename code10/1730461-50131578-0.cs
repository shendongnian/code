        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn() { ColumnName = "Name", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn() { ColumnName = "Id", DataType = typeof(int) });
            for (int i = 0; i < 20; i++) // Add 20 Rows
            {
                DataRow row = dt.Rows.Add();
                row["Id"] = i;
                row["Name"] = i.ToString();
            }
            for (int i = 0; i < dt.Columns.Count; i++) // Loop through all columns
            {
                Console.Write(dt.Columns[i].ColumnName + ";");
            }
            Console.WriteLine();
            foreach (DataRow r in dt.Rows) // Generic looping through DataTable
            {
                for (int i = 0; i < dt.Columns.Count; i++) // Loop through all columns
                {
                    Console.Write(r[i] + ";");
                }
                Console.WriteLine();
            }
        }
