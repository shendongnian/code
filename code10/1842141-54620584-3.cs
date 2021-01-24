	List<MyData> records = null;
	using (var reader = new StreamReader(myfile))
    using (var csv = new CsvReader(reader))
    {
	    csv.Configuration.HasHeaderRecord = true;
	    csv.Configuration.IgnoreQuotes = false;
		csv.Configuration.Delimiter = ",";
		csv.Configuration.RegisterClassMap<MyDataMapper>();
		records = csv.GetRecords<MyData>().ToList();
		dt = records.Select(x=>dt.LoadDataRow(new object[]
				{
					x.Id,
					x.MaxDiscount,
					x.Name,
					x.Active,
					x.AltId
				},false))
				.CopyToDataTable();
         dt.Dump();
