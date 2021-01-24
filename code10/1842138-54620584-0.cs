	string myfile = @"FullPathToFile.csv";
	DataTable dt = new DataTable();
	using (var reader = new StreamReader(myfile))
    using (var csv = new CsvReader(reader))
    {
	    csv.Configuration.HasHeaderRecord = true;
	    csv.Configuration.IgnoreQuotes = false;
		csv.Configuration.Delimiter = ",";
		using (var dr = new CsvDataReader(csv))
		{
			dt.Load(dr);
		}
    }
