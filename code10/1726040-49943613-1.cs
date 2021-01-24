	string[] lines = File.ReadAllLines(files);
	foreach (var line in lines)
	{
		string[] items = line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
		DataRow row = dt.NewRow();
		if (!line.Contains(elt)) continue; // I have an enum with "element1" "element2" and "element3"
			row[items[2]] = items[3];
		dt.Rows.Add(row);
	}
	
	
