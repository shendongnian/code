    ...
    try
    {
    	adapter.Fill(dataTable); // or dataSet
    }
    catch (ConstraintException)
    {
    	LogErrors(dataTable);
    	throw;
    }
    ...
    
    private static void LogErrors(DataSet dataSet)
    {
    	foreach (DataTable dataTable in dataSet.Tables)
    	{
    		LogErrors(dataTable);
    	}
    }
    
    private static void LogErrors(DataTable dataTable)
    {
    	if (!dataTable.HasErrors) return;
    	StringBuilder sb = new StringBuilder();
    	sb.AppendFormat(
    		CultureInfo.CurrentCulture,
    		"ConstraintException while  filling {0}",
    		dataTable.TableName);
    	DataRow[] errorRows = dataTable.GetErrors();
    	for (int i = 0; (i < MAX_ERRORS_TO_LOG) && (i < errorRows.Length); i++)
    	{
    		sb.AppendLine();
    		sb.Append(errorRows[i].RowError);
    	}
    	_logger.Error(sb.ToString());
    }
