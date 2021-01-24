	string[] values;
	string header;
	string line, city, outputFileName;
	string inputFile = "full list.csv";
	Dictionary<string, System.IO.StreamWriter> outputFiles = new Dictionary<string, System.IO.StreamWriter>();
	using (System.IO.StreamReader file = new System.IO.StreamReader(inputFile))
	{
		header = file.ReadLine();
		while ((line = file.ReadLine()) != null)
		{
			values = line.Split(",".ToCharArray());
			city = values[1];
			if (!outputFiles.ContainsKey(city))
			{
				outputFileName = "full list_" + city + ".csv";
				outputFiles.Add(city, new System.IO.StreamWriter(outputFileName));
				outputFiles[city].WriteLine(header);
			}
			outputFiles[city].WriteLine(line);
		}
	}   
	foreach(System.IO.StreamWriter outputFile in outputFiles.Values)
	{
		outputFile.Close();
	}
