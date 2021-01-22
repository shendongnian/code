	// Create new ExcelFile
	ExcelFile ef = new ExcelFile();
	// Add sheet
	ExcelWorksheet ws = ef.Worksheets.Add("Sheet1");
	// Fill sheet
	for (int i = 0; i < 5; i++)
	{
		ws.Cells[i, 0].Value = i;   // integer value
		ws.Cells[i, 1].Value = "Row: " + i; // string value
	}
	// Initialize DataTable
	DataTable dt = new DataTable();
	dt.Columns.Add("id", typeof(string));
	dt.Columns.Add("text", typeof(string));
	// Manage ExtractDataError.WrongType error
	ws.ExtractDataEvent += (sender, e) =>
	{
		if (e.ErrorID == ExtractDataError.WrongType)
		{
			e.DataTableValue = e.ExcelValue == null ? null : e.ExcelValue.ToString();
			e.Action = ExtractDataEventAction.Continue;
		}
	};
	// Extract data to DataTable
	ws.ExtractToDataTable(dt, 1000, ExtractDataOptions.StopAtFirstEmptyRow, ws.Rows[0], ws.Columns[0]);
