	const string LocationColumn = "Location";
	const string ItemTypeColumn = "Item Type";
	
	public DataTable CombineofAdjustmentNTransaction(DataTable tableA, DataTable tableB)
	{
		DataTable result = new DataTable();
		result.Columns.Add(new DataColumn(LocationColumn));
		result.Columns.Add(new DataColumn(ItemTypeColumn));
		result.Columns.Add(new DataColumn("AmountA"));
		result.Columns.Add(new DataColumn("AmountB"));
		result.Columns.Add(new DataColumn("Type"));
		foreach (DataRow rowA in tableA.Rows)
		foreach (DataRow rowB in tableB.Rows)
		{
			// check for conditions
			if (rowB[LocationColumn] != rowA[LocationColumn]) continue;
			if (rowB[ItemTypeColumn] != rowA[ItemTypeColumn]) continue;
			// create a new row template
			Func<DataRow> newRowTemplate = () =>
			{	
				DataRow newRow = result.NewRow();
				newRow[LocationColumn] = rowA[LocationColumn];
				newRow[ItemTypeColumn] = rowA[ItemTypeColumn];
				return newRow;
			};
			// create rows for A and B using the template
			DataRow newRowA = newRowTemplate();
			DataRow newRowB = newRowTemplate();
			// your logic for A
			if (rowA["Type"].ToString() == "GRN")
			{
				newRowA["AmountA"] = rowA["AmountA"];
				newRowA["Type"] = "GRN";
				
				// add the row
				result.Rows.Add(newRowA);
			}
			
			// your logic for B
			if (rowB["Type"].ToString() == "STK_ADJ")
			{
				newRowA["AmountB"] = rowB["AmountB"];
				newRowA["Type"] = "STK_ADJ";
				
				// add the row
				result.Rows.Add(newRowB);
			}
		}
		
		return result;	
	}
