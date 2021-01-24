    DataTable table = new DataTable();
    table.Columns.Add("Col1", typeof(int));
    table.Columns.Add("Col2", typeof(string));
    table.Columns.Add("Col3", typeof(string));
    
    
    //Your data
    table.Rows.Add(1, "A", "B");
    table.Rows.Add(2, "A", "B");
    table.Rows.Add(3, "C", "C");
    table.Rows.Add(4, "C", "");
    
    //Type
    string chosen = "Col2"; //User-chosen grouping type.
    List<string> columns = new List<string> { "Col1", "Col2", "Col3" };
    
    
    //LINQ 
    var query = table.AsEnumerable().GroupBy(x => x[chosen]).Select(x => {
    
    	ArrayList sampleObject = new ArrayList();
    	foreach (var count_col in columns)
    	{
    		if (count_col == chosen)
    		{
    			sampleObject.Add(x.Key.ToString());
    		}
    		else
    		{
    			sampleObject.Add(x.Sum(y => y[count_col].ToString() == "" ? 0 : 1));
    		}
    		
    	}
    
    	return sampleObject;
    });
    
    //result
    foreach (var r in query)
    {
    	Console.WriteLine("{0}\t{1}\t{2}", r[0], r[1], r[2]);
    }
