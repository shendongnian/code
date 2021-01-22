    private void RenderDataTableOnXlSheet(DataTable dt, Excel.Worksheet xlWk, 
                                        string [] columnNames, string [] fieldNames)
    {
    	// render the column names (e.g. headers)
    	int columnLength = columnNames.Length;
    	for (int i = 0; i < columnLength; i++)
    		xlWk.Cells[1, i + 1] = columnNames[i];
    
    	// render the data 
    		int fieldLength = fieldNames.Length;
    		int rowCount = dt.Rows.Count;
    		for (int j = 0; j < rowCount; j++)
    		{ 
    			for (int i = 0; i < fieldLength; i++)
    			{
    				xlWk.Cells[j + 2, i + 1] = dt.Rows[j][fieldNames[i]].ToString();
    			}
    		}
    }
