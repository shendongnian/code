    public string DataTableToCSV(DataTable dt)
    {
    	StringBuilder sb = new StringBuilder();
    	if (dt == null)
    		return "";
    	try {
    		// Create the header row
    		for (int i = 0; i <= dt.Columns.Count - 1; i++) {
    			// Append column name in quotes
    			sb.Append("\"" + dt.Columns[i].ColumnName + "\"");
    			// Add carriage return and linefeed if last column, else add comma
    			sb.Append(i == dt.Columns.Count - 1 ? "\n" : ",");
    		}
    
    
    		foreach (DataRow row in dt.Rows) {
    			for (int i = 0; i <= dt.Columns.Count - 1; i++) {
    				// Append value in quotes
    				//sb.Append("""" & row.Item(i) & """")
    
    				// OR only quote items that that are equivilant to strings
    				sb.Append(object.ReferenceEquals(dt.Columns[i].DataType, typeof(string)) || object.ReferenceEquals(dt.Columns[i].DataType, typeof(char)) ? "\"" + row[i] + "\"" : row[i]);
    				// Append CR+LF if last field, else add Comma
    				sb.Append(i == dt.Columns.Count - 1 ? "\n" : ",");
    			}
    		}
    		return sb.ToString;
    	} catch (Exception ex) {
    		// Handle the exception however you want
    		return "";
    	}
    }
