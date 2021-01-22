	public static System.Data.DataTable CreateDataTableFromXmlFile(string xmlFilePath)
	{
		System.Data.DataTable Dt = new System.Data.DataTable();
		
		string input = File.ReadAllText(xmlFilePath);
		var xmlTagsAndValues = GetXMlTagsAndValues(input);
		var columnList = new List<string>();
		foreach (var xml in xmlTagsAndValues)
		{
			if (!columnList.Contains(xml.Item1))
			{
				columnList.Add(xml.Item1);
				Dt.Columns.Add(xml.Item1, typeof(string));
			}                   
			else 
			{
				var columnName = xml.Item1;
				do
				{
					columnName = columnName.Increment();
				} while (columnList.Contains(columnName));
				columnList.Add(columnName);
				Dt.Columns.Add(columnName, typeof(string));
			}
		}
		DataRow dtrow = Dt.NewRow();
		var columnList2 = new Dictionary<string, string>();  
		
		foreach (var xml in xmlTagsAndValues)
		{
			if (!columnList2.Keys.Contains(xml.Item1))
			{
				dtrow[xml.Item1] = xml.Item2;
				columnList2.Add(xml.Item1, xml.Item2);
			}
			else
			{
				var columnName = xml.Item1;
				do
				{
					columnName = columnName.Increment();
				} while (columnList2.Keys.Contains(columnName));
				
				dtrow[columnName] = xml.Item2;
				columnList2[columnName] = xml.Item2;
			}			
		}
		Dt.Rows.Add(dtrow);
		
		return Dt;
	}
