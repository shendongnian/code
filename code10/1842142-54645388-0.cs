    static void Load(DataTable dt, CsvReader csv)
    {
    	if (csv.Configuration.HasHeaderRecord)
    	{
    		if (!csv.Read()) return;
    		csv.ReadHeader();
    	}
    	var valueTypes = new Type[dt.Columns.Count];
    	for (int i = 0; i < valueTypes.Length; i++)
    	{
    		var dc = dt.Columns[i];
    		var type = dc.DataType;
    		if (dc.AllowDBNull && type.IsValueType)
    			type = typeof(Nullable<>).MakeGenericType(type);
    		valueTypes[i] = type;
    	}
    	var valueBuffer = new object[valueTypes.Length];
    	dt.BeginLoadData();
    	while (csv.Read())
    	{
    		for (int i = 0; i < valueBuffer.Length; i++)
    			valueBuffer[i] = csv.GetField(valueTypes[i], i);
    		dt.LoadDataRow(valueBuffer, true);
    	}
    	dt.EndLoadData();
    }
