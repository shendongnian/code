    var dt = new DataTable();
    using (var rdr = new CsvDataReader(file, true)) // set true if the csv has header line, false otherwise
    {
        //rdr.ColumnTypes = new Type[] { typeof(int), typeof(string), typeof(int) }; Uncomment this if you know the structure of the csv
        dt.Load(rdr);
    }
    foreach (DataRow r in dt.Rows)
    {
        for (int i = 0; i < dt.Columns.Count; i++)
            Console.Write($"{dt.Columns[i]}:{r[i]}  ");
        Console.WriteLine("");
    }
