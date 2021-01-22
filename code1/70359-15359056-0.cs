    public static string DataTable2String(DataTable dataTable)
    {
    	StringBuilder sb = new StringBuilder();
    	if (dataTable != null)
    	{
    		string seperator = " | ";
    
    		#region get min length for columns
    		Hashtable hash = new Hashtable();
    		foreach (DataColumn col in dataTable.Columns)
    			hash[col.ColumnName] = col.ColumnName.Length;
    		foreach (DataRow row in dataTable.Rows)
    			for (int i = 0; i < row.ItemArray.Length; i++)
    				if (row[i] != null)
    					if (((string)row[i]).Length > (int)hash[dataTable.Columns[i].ColumnName])
    						hash[dataTable.Columns[i].ColumnName] = ((string)row[i]).Length;
    		int rowLength = (hash.Values.Count + 1) * seperator.Length;
    		foreach (object o in hash.Values)
    			rowLength += (int)o;
    		#endregion get min length for columns
    
    		sb.Append(new string('=', (rowLength - " DataTable ".Length) / 2));
    		sb.Append(" DataTable ");
    		sb.AppendLine(new string('=', (rowLength - " DataTable ".Length) / 2));
    		if (!string.IsNullOrEmpty(dataTable.TableName))
    			sb.AppendLine(String.Format("{0,-" + rowLength + "}", String.Format("{0," + ((rowLength + dataTable.TableName.Length) / 2).ToString() + "}", dataTable.TableName)));
    		
    		#region write values
    		foreach (DataColumn col in dataTable.Columns)
    			sb.Append(seperator + String.Format("{0,-" + hash[col.ColumnName] + "}", col.ColumnName));
    		sb.AppendLine(seperator);
    		sb.AppendLine(new string('-', rowLength));
    		foreach (DataRow row in dataTable.Rows)
    		{
    			for (int i = 0; i < row.ItemArray.Length; i++)
    			{
    				sb.Append(seperator + String.Format("{0," + hash[dataTable.Columns[i].ColumnName] + "}", row[i]));
    				if (i == row.ItemArray.Length - 1)
    					sb.AppendLine(seperator);
    			}
    		}
    		#endregion write values
    
    		sb.AppendLine(new string('=', rowLength));
    	}
    	else
    		sb.AppendLine("================ DataTable is NULL ================");
    
    	return sb.ToString();
    }
