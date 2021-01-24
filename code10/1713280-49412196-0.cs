    //Convert table to CSV-formatted string
    
    //Add header
    StringBuilder accountSB = new StringBuilder();
    for (int i = 0; i < tblAccount.Columns.Count; i++)
    {
    	string columnName = tblAccount.Columns[i].ColumnName);
    	accountSB.Append("\"" + columnName + "\"");
    	if (i < tblAccount.Columns.Count - 1)
    		accountSB.Append(',');
    }
    
    accountSB.AppendLine();
    
    //Add row data
    foreach (DataRow dr in tblAccount.Rows)
    {
    	for (int i = 0; i < tblAccount.Columns.Count; i++)
    	{
    		accountSB.Append("\"" + dr[i].ToString() + "\"");
    
    		if (i < tblAccount.Columns.Count - 1)
    			accountSB.Append(',');
    	}
    	accountSB.AppendLine();
    }
    
    //Further processing...
