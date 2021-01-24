    DataTable table = new DataTable();
    
    table.Columns.Add("C1",typeof(string));
    table.Columns.Add("C2",typeof(decimal));
    table.Columns.Add("C3",typeof(char));
    
    for(int i = 65; i < 65 + 10; i++)
    {
    	var row = table.NewRow();
    	row[0] = "string"+i.ToString();
    	row[1] = i;
    	row[2] = (char)i;
    	table.Rows.Add(row);
    }
    
    List<Tuple<string, decimal, char>> results = new List< Tuple<string, decimal, char>>();
    
    foreach (DataRow r in table.Rows)
    {
    	var tup = Tuple.Create((string)r[0], (decimal)r[1], (char)r[2]);
    	results.Add(tup);
    }
