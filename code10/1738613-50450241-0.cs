    static void Main(string[] args)
    {
    	var dt = new DataTable("Numbers");
    	dt.Columns.Add(new DataColumn { DataType = typeof(int), ColumnName = "Num" });
    	using (var zip = ZipFile.OpenRead(@"PATH_TO_ZIP"))
    	{
    		var entry = zip.GetEntry("PATH_TO_FILE_IN_ZIP");
    		{
    			using (var stream = entry.Open())
    			{
    				using (var sr = new StreamReader(stream))
    				{
    					while(!sr.EndOfStream)
    					{
    						string line = sr.ReadLine();
    						var row = dt.NewRow();
    						row["Num"] = line;
    						dt.Rows.Add(row);
    					}
    				}
    			}
    		}
    	}
    }
