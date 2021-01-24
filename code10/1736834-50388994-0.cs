	DataTable table = new DataTable();
	table.Columns.Add("TotalPrice", typeof(int));
	table.Columns.Add("ComboAmount", typeof(int));
	// Here we add five DataRows.
	table.Rows.Add(10,10);
	table.Rows.Add(20,20);
	table.Rows.Add(30,20);
	DataTable dtOrderReceipt = new DataTable(); 
	dtOrderReceipt.Columns.Add("FinalAmount", typeof(int));
	for (int i = 0; i < table.Rows.Count; i++)
	{
		DataRow dtItemRow = dtOrderReceipt.NewRow();
		dtOrderReceipt.Rows.InsertAt(dtItemRow, i);
		dtItemRow["FinalAmount"] = (int)table.Rows[i]["ComboAmount"] + (int)table.Rows[i]["TotalPrice"];
	}
