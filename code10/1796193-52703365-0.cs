    List<int> skippedColumnOrdinals = new List<int>();
	string[] skipWhenContains = { "code", "Q", "M" };
	for (int index = 0; index < colFields.Length; index++)
	{
		string column = colFields[index];
		bool skipColumn = skipWhenContains.Any(column.Contains);
		if (skipColumn)
		{
			skippedColumnOrdinals.Add(index);
			continue;
		}
		DataColumn datecolumn = new DataColumn(column) { AllowDBNull = true };
		csvData.Columns.Add(datecolumn);
	}
	while (!csvReader.EndOfData)
	{
		string[] fieldData = csvReader.ReadFields()
            .Where((field, index) => !skippedColumnOrdinals.Contains(index))
            .Select(field => field == "" ? null : field)
            .ToArray();
		csvData.Rows.Add(fieldData);
	}
