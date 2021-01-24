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
	        if (rowB[Column1Location] != rowA[Column1Location]) continue;
	        if (rowB[Column2ItemType] != rowA[Column2ItemType]) continue;
	
	        // create a new row template
	        Func<DataRow> newRowTemplate = () =>
	        {   
	            DataRow newRow = result.NewRow();
	            newRow[Column1Location] = rowA[Column1Location];
	            newRow[Column2ItemType] = rowA[Column2ItemType];
	
	            return newRow;
	        };
	
	        // create rows for A and B using the template
	        DataRow newRowA = newRowTemplate();
	        DataRow newRowB = newRowTemplate();
	
	        // your logic for A
	        if (rowA["Type"].ToString() == "GRN")
	        {
	            newRowA[Column3AmountA] = rowA["AmountA"];
	            newRowA[Column5TransactionType] = "GRN";
	
					// add the row
					result.Rows.Add(newRowA);
				}
	
				// your logic for B
				if (rowB["Type"].ToString() == "STK_ADJ")
				{
					newRowA[Column4AmountB] = rowB["AmountB"];
					newRowA[Column5TransactionType] = "STK_ADJ";
	
					// add the row
					result.Rows.Add(newRowB);
				}
			}
	
		return result;
	}
