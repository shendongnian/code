    int[] array;
    using (DataTable table = GetTable())
    {
        array = (from DataRow row in table.Rows
                    select
                    (from DataColumn col in table.Columns
                    select row[col].ToString().Length).Sum()).ToArray();
    }
    foreach (int value in array)
        Console.WriteLine(value);
