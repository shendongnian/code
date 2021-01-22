    public static List<string> ToCSV(this DataSet ds, char separator = '|')
    {
    	List<string> lResult = new List<string>();
    
    	foreach (DataTable dt in ds.Tables)
    	{
    		StringBuilder sb = new StringBuilder();
    		IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
    										  Select(column => column.ColumnName);
    		sb.AppendLine(string.Join(separator.ToString(), columnNames));
    
    		foreach (DataRow row in dt.Rows)
    		{
    			IEnumerable<string> fields = row.ItemArray.Select(field =>
    			  string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
    			sb.AppendLine(string.Join(separator.ToString(), fields));
    		}
    
    		lResult.Add(sb.ToString());
    	}
    	return lResult;
    }
    
    public static DataSet CSVtoDataSet(this List<string> collectionCSV, char separator = '|')
    {
    	var ds = new DataSet();
    
    	foreach (var csv in collectionCSV)
    	{
    		var dt = new DataTable();
    
    		var readHeader = false;
    		foreach (var line in csv.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
    		{
    			if (!readHeader)
    			{
    				foreach (var c in line.Split(separator))
    					dt.Columns.Add(c);
    			}
    			else
    			{
    				dt.Rows.Add(line.Split(separator));
    			}
    		}
    
    		ds.Tables.Add(dt);
    	}
    
    	return ds;
    }
