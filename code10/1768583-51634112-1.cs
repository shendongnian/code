	List<string> customBindingRow;
	List<List<string>> customBindingData = new List<List<string>>();
	for (int i = 0; i < 10; i++)
	{
		
		customBindingRow = new List<string>();
		for (int j = 0; j < 2; j++)
		{
			customBindingRow.Add("i=" + i.ToString() + "j=" + j.ToString());
		}
		customBindingData.Add(customBindingRow);
	}
	//Using stringbuilser will reduce the memory usage.
	//Adding text to a string will create a new reference in memory, you should avoid this.
	StringBuilder text = new StringBuilder();
	foreach (List<string> dt in customBindingData)
	{
		text.Append( string.Join(",", dt.ToArray()) + "\r\n");
	}
	Console.WriteLine(text.ToString());
