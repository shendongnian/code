    /// <summary>
    /// Takes a datatable and a column index, and returns a datatable without duplicates
    /// </summary>
    /// <param name="dt">The datatable containing duplicate records</param>
    /// <param name="ComparisonFieldIndex">The column index containing duplicates</param>
    /// <returns>A datatable object without duplicated records</returns>
    public DataTable duplicateRemoval(DataTable dt, int ComparisonFieldIndex)
    {
    	try
    	{
    		//Build the new datatable that will be returned
    		DataTable dtReturn = new DataTable();
    		for (int i = 0; i < dt.Columns.Count; i++)
    		{
    			dtReturn.Columns.Add(dt.Columns[i].ColumnName, System.Type.GetType("System.String"));
    		}
    
    		//Loop through each record in the datatable we have been passed
    		foreach (DataRow dr in dt.Rows)
    		{
    			bool Found = false;
    			//Loop through each record already present in the datatable being returned
    			foreach (DataRow dr2 in dtReturn.Rows)
    			{
    				bool Identical = true;
    				//Compare the column specified to see if it matches an existing record
    				if (!(dr2[ComparisonFieldIndex].ToString() == dr[ComparisonFieldIndex].ToString()))
    				{
    					Identical = false;
    				}
    				//If the record found identically matches one we already have, don't add it again
    				if (Identical)
    				{
    					Found = true;
    					break;
    				}
    			}
    			//If we didn't find a matching record, we'll add this one
    			if (!Found)
    			{
    				DataRow drAdd = dtReturn.NewRow();
    				for (int i = 0; i < dtReturn.Columns.Count; i++)
    				{
    					drAdd[i] = dr[i];
    				}
    
    				dtReturn.Rows.Add(drAdd);
    			}
    		}
    		return dtReturn;
    	}
    	catch (Exception)
    	{
    		//Return the original datatable if something failed above
    		return dt;
    	}
    }
