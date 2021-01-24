    using System;
    using System.Data;
    
    class Program
    {
        static void Main()
        {
            //
            // Loop over DataTable rows and call the Field extension method.
            //
            foreach (DataRow row in GetTable().Rows)
            {
                // Get first field by column index.
                int weight = row.Field<int>(0);
    
                // Get second field by column name.
                string name = row.Field<string>("Name");
    
                // Get third field by column index.
                string code = row.Field<string>(2);
    
                // Get fourth field by column name.
                DateTime date = row.Field<DateTime>("Date");
    
                // Display the fields.
                Console.WriteLine("{0} {1} {2} {3}", weight, name, code, date);
            }
        }
    
        static DataTable GetTable()
        {
            DataTable table = new DataTable(); // Create DataTable
            table.Columns.Add("Weight", typeof(int)); // Add four columns
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Code", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Rows.Add(57, "Koko", "A", DateTime.Now); // Add five rows
            table.Rows.Add(130, "Fido", "B", DateTime.Now);
            table.Rows.Add(92, "Alex", "C", DateTime.Now);
            table.Rows.Add(25, "Charles", "D", DateTime.Now);
            table.Rows.Add(7, "Candy", "E", DateTime.Now);
            return table;
        }
    }
