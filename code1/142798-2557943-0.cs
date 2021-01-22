    foreach (DataColumn column in loadDT.Columns)
    {
        Console.Write("Item: ");
        Console.Write(column.ColumnName);
        Console.Write(" ");
        Console.WriteLine(item);
    }
