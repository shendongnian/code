    public class Csv
    {
    	public static DataTable DataSetGet(string filename, string separatorChar, out List<string> errors)
    	{
    		errors = new List<string>();
    		var table = new DataTable("StringLocalization");
    		using (var sr = new StreamReader(filename, Encoding.Default))
    		{
    			string line;
    			var i = 0;
    			while (sr.Peek() >= 0)
    			{
    				try
    				{
    					line = sr.ReadLine();
    					if (string.IsNullOrEmpty(line)) continue;
    					var values = line.Split(new[] {separatorChar}, StringSplitOptions.None);
    					var row = table.NewRow();
    					for (var colNum = 0; colNum < values.Length; colNum++)
    					{
    						var value = values[colNum];
    						if (i == 0)
    						{
    							table.Columns.Add(value, typeof (String));
    						}
    						else
    						{
    							row[table.Columns[colNum]] = value;
    						}
    					}
    					if (i != 0) table.Rows.Add(row);
    				}
    				catch(Exception ex)
    				{
    					errors.Add(ex.Message);
    				}
    				i++;
    			}
    		}
    		return table;
    	}
    }
