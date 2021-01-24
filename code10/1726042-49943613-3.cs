    string[] myenum = Enum.GetNames(typeof(allenum));
    DataTable dt = new DataTable();
    foreach (string enum in myenum)
    {
    	string[] lines = File.ReadAllLines(files);
    	foreach (var line in lines)
    	{
    		string[] items = line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
    		DataRow row = dt.NewRow();
    		if (!line.Contains(enum)) continue; // I have an enum with "element1" "element2" and "element3"
    			row[items[2]] = items[3];
    		dt.Rows.Add(row);
    	}
    }
    	
	
