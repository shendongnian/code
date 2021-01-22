    public static String ToCSV(this DataTable dataTable)
    {
    	return dataTable.ToCSV(null, COMMA, true);
    }  
    public static String ToCSV(this DataTable dataTable, String qualifier)
    {
    	return dataTable.ToCSV(qualifier, COMMA, true);
    }
    private static String ToCSV(this DataTable dataTable, String qualifier, String delimiter, Boolean includeColumnNames)
    {
    	if (dataTable == null) return null;
    
    	if (qualifier == delimiter)
    	{
    		throw new InvalidOperationException(
    			"The qualifier and the delimiter are identical. This will cause the CSV to have collisions that might result in data being parsed incorrectly by another program.");
    	}
    
    	var sbCSV = new StringBuilder();
    
    	var delimiterToUse = delimiter ?? COMMA;
    
    	if (includeColumnNames) 
    		sbCSV.AppendLine(dataTable.Columns.GetHeaderLine(qualifier, delimiterToUse));
        
    	foreach (DataRow row in dataTable.Rows)
    	{
    		sbCSV.AppendLine(row.ToCSVLine(qualifier, delimiterToUse));
    	}
    
    	return sbCSV.Length > 0 ? sbCSV.ToString() : null;
    }
    private static String ToCSVLine(this DataRow dataRow, String qualifier, String delimiter)
    {
    	var colCount = dataRow.Table.Columns.Count;
    	var rowValues = new String[colCount];
        
    	for (var i = 0; i < colCount; i++)
    	{
    		rowValues[i] = dataRow[i].Qualify(qualifier);
    	}
    
    	return String.Join(delimiter, rowValues);
    }
    private static String GetHeaderLine(this DataColumnCollection columns, String qualifier, String delimiter)
    {
    	var colCount = columns.Count;
    	var colNames = new String[colCount];
    
    	for (var i = 0; i < colCount; i++)
    	{
    		colNames[i] = columns[i].ColumnName.Qualify(qualifier);
    	}
    
    	return String.Join(delimiter, colNames);
    }
    private static String Qualify(this Object target, String qualifier)
    {
    	return qualifier + target + qualifier;
    }
