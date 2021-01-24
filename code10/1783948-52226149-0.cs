    DataTable tbl1 = new DataTable("table1");
    tbl1.Columns.Add(new DataColumn("col1"));
    tbl1.Columns.Add(new DataColumn("col2"));
    tbl1.Columns.Add(new DataColumn("col3"));
    tbl1.Columns.Add(new DataColumn("col4"));
    tbl1.Columns.Add(new DataColumn("col5"));
    tbl1.Columns.Add(new DataColumn("col6"));
    tbl1.Columns.Add(new DataColumn("col7"));
    tbl1.Columns.Add(new DataColumn("col8"));
    tbl1.Columns.Add(new DataColumn("col9"));
    tbl1.Columns.Add(new DataColumn("col10"));
    tbl1.Rows.Add("abc", "def", "abc", "zxv", "was", "morning", "def", "dr", "tr", "uy");
    tbl1.Rows.Add("abc2", "def2", "abc3", "zxv4", "was4", "morning2", "def2", "dr3", "tr3", "uy");
    // mapping dictionary keys represent the table data, values represent the unique id
    var mapping = new Dictionary<string, int>();
    // loop through table and add all unique items to the dictionary
    foreach (DataRow row in tbl1.Rows)
    {
        foreach (DataColumn col in tbl1.Columns)
        {
            var value = row[col].ToString();
            if (!mapping.ContainsKey(value))
            {
                mapping.Add(value, mapping.Count + 1);
            }
        }
    }
    // Output our mappings
    foreach (DataRow row in tbl1.Rows)
    {
        Console.WriteLine(string.Join(",", row.ItemArray.Select(item => mapping[item.ToString()])));
    }
