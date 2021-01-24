    static void Main(string[] args)
    {
        DataTable dt = new DataTable(); // Create a example-DataTable
        dt.Columns.Add(new DataColumn() { ColumnName = "Name", DataType = typeof(string) }); // Add some columns
        dt.Columns.Add(new DataColumn() { ColumnName = "Id", DataType = typeof(int) });
        // Let's fill the table with some rows
        for (int i = 0; i < 20; i++) // Add 20 Rows
        {
            DataRow row = dt.Rows.Add(); // Generate a row
            row["Id"] = i; // Fill in some data to the row. We can access the columns which we added.
            row["Name"] = i.ToString();
        }
        // Let's see what we got.
        for (int i = 0; i < dt.Columns.Count; i++) // Loop through all columns
        {
            Console.Write(dt.Columns[i].ColumnName + ";"); // Write the ColunName to the console with a ';' a seperator.
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
