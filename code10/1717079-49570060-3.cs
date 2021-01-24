    foreach (DataRow row in dtfinal.Rows)
    {
        foreach (DataColumn column in dtfinal.Columns)
        {
            Console.Write("Item: ");
            Console.Write(column.ColumnName);
            Console.Write(" ");
            Console.WriteLine(row[column]);
        }
    }
