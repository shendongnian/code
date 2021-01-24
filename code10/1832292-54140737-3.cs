	const string Column1Location = "Location";
	const string Column2ItemType = "Item Type";
	const string Column3AmountA = "Amount A";
	const string Column4AmountB = "Amount B";
	const string Column5TransactionType = "Transaction Type";
	
	public DataTable CombineofAdjustmentNTransaction(DataTable tableA, DataTable tableB)
	{
	    DataTable result = new DataTable();
	    result.Columns.Add(new DataColumn(Column1Location));
	    result.Columns.Add(new DataColumn(Column2ItemType));
	    result.Columns.Add(new DataColumn(Column3AmountA));
	    result.Columns.Add(new DataColumn(Column4AmountB));
	    result.Columns.Add(new DataColumn(Column5TransactionType));
	
	    foreach (DataRow rowA in tableA.Rows)
	    foreach (DataRow rowB in tableB.Rows)
	    {
	        // check for conditions
	        if (rowA["Location"] != rowB["Location"]) continue;
	        if (rowA["ItemType"] != rowB["Item Type"]) continue;
	
	        // create a new row template
	        Func<DataRow> newRowTemplate = () =>
	        {   
	            DataRow newRow = result.NewRow();
	            newRow[Column1Location] = rowA["Location"];
	            newRow[Column2ItemType] = rowA["Item Type"];
	
	            return newRow;
	        };	
	
	        // your logic for A
	        if (rowA["Type"].ToString() == "GRN")
	        {
		        // create row using the template
		        DataRow newRowA = newRowTemplate();
	            newRowA[Column3AmountA] = rowA["AmountA"];
	            newRowA[Column5TransactionType] = "GRN";
	
				// add the row
				result.Rows.Add(newRowA);
			}
	
			// your logic for B
			if (rowB["Type"].ToString() == "STK_ADJ")
			{
		        // create row using the template
		        DataRow newRowB = newRowTemplate();
				newRowA[Column4AmountB] = rowB["AmountB"];
				newRowA[Column5TransactionType] = "STK_ADJ";
				// add the row
				result.Rows.Add(newRowB);
			}
		}
	
		return result;
	}
