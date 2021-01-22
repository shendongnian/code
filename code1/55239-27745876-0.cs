    public static void ToPrintConsole(this DataTable dataTable)
        {
            // Print top line
            Console.WriteLine(new string('-', 75));
            // Print col headers
            var colHeaders = dataTable.Columns.Cast<DataColumn>().Select(arg => arg.ColumnName);
            foreach (String s in colHeaders)
            {
                Console.Write("| {0,-20}", s);
            }
            Console.WriteLine();
            // Print line below col headers
            Console.WriteLine(new string('-', 75));
            // Print rows
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (Object o in row.ItemArray)
                {
                    Console.Write("| {0,-20}", o.ToString());
                }
                Console.WriteLine();
            }
            // Print bottom line
            Console.WriteLine(new string('-', 75));
        }
