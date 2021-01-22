    int[][] lengths;
    using (DataTable table = GetTable())
    {
        lengths = (from DataRow row in table.Rows
                    select
                    (from DataColumn col in table.Columns
                    select row[col].ToString().Length).ToArray()).ToArray();
    }
    foreach (int[] row in lengths)
    {
        Console.WriteLine(string.Join(",", row));
    }
