	string file = @"fakepath\abc.xlsx";
	DataSet result = new DataSet();
	//------To read the xlsx file
	if (file.EndsWith(".xlsx"))
	{
		// Reading from a binary Excel file (format; *.xlsx)
		FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
		IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
		result = excelReader.AsDataSet();
		excelReader.Close();
	}
	//-------To convert the file into csv format
	while (row_no < result.Tables[0].Rows.Count)
	{
		for (int i = 0; i < result.Tables[0].Columns.Count; i++)
		{
			var column = result.Tables[0].Rows[row_no][i].ToString();
			column.Split(new[] { '\r', '\n' }).ToList().ForEach(column_line => { a += column_line + "," ;});
		}
		row_no++;
		a += Environment.NewLine;
		//or
		// a += "\r\n";
	}
	string output = @"fakepath\abc.csv";
	StreamWriter csv = new StreamWriter(@output, false);
	csv.Write(a);
	csv.Close();
