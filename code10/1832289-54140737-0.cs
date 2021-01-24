	public DataTable CombineofAdjustmentNTransaction(DataTable tableA, DataTable tableB)
	{
		DataTable result = new DataTable();
		result.Columns.Add(new DataColumn("Location"));
		result.Columns.Add(new DataColumn("Item Type"));
		result.Columns.Add(new DataColumn("AmountA)"));
		result.Columns.Add(new DataColumn("AmountB"));
		result.Columns.Add(new DataColumn("TransactionType"));
		foreach (DataRow rowA in tableA.Rows)
		foreach (DataRow rowB in tableB.Rows)
		{
			// check for conditions
			if (rowB["Location"] != rowA["Location"]) continue;
			if (rowB["Item Type"] != rowA["Item Type"]) continue;
			// create a row for A
			DataRow newRowA = result.NewRow();
			newRowA["Location"] = rowA["Location"];
			newRowA["Item Type"] = rowA["Item Type"];
			if (rowA["Type"].ToString() == "GRN")
			{
				newRowA["AmountA"] = rowA["AmountA"];
				newRowA["Type"] = "GRN";
			}
			// create a row for B
			DataRow newRowB = result.NewRow();
			newRowB["Location"] = rowB["Location"];
			newRowB["Item Type"] = rowB["Item Type"];
			if (rowB["Type"].ToString() == "STK_ADJ")
			{
				newRowA["AmountB"] = rowB["AmountB"];
				newRowA["Type"] = "STK_ADJ";
			}
			// add the rows
			result.Rows.Add(newRowA);
			result.Rows.Add(newRowB);
		}
	}
	
	return result;	
}
