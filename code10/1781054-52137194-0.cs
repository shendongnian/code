	[TestMethod]
	public void EmptyRowsTest()
	{
		//Throw in some data
		var datatable = new DataTable("tblData");
		datatable.Columns.AddRange(new[] { new DataColumn("Col1", typeof(int)), new DataColumn("Col2", typeof(int)), new DataColumn("Col3", typeof(object)) });
		//Only fille every other row
		for (var i = 0; i < 10; i++)
		{
			var row = datatable.NewRow();
			if (i % 2 > 0)
			{
				row[0] = i;
				row[1] = i * 10;
				row[2] = Path.GetRandomFileName();
			}
			datatable.Rows.Add(row);
		}
		//Create a test file
		var existingFile = new FileInfo(@"c:\temp\EmptyRowsTest.xlsx");
		if (existingFile.Exists)
			existingFile.Delete();
		using (var pck = new ExcelPackage(existingFile))
		{
			var worksheet = pck.Workbook.Worksheets.Add("Sheet1");
			worksheet.Cells.LoadFromDataTable(datatable, true);
			pck.Save();
		}
		//Load from file
		using (var pck = new ExcelPackage(existingFile))
		{
			var worksheet = pck.Workbook.Worksheets["Sheet1"];
			//Cells only contains references to cells with actual data
			var cells = worksheet.Cells;
			var rowIndicies = cells
				.Select(c => c.Start.Row)
				.Distinct()
				.ToList();
			//Skip the header row which was added by LoadFromDataTable
			for (var i = 1; i <= 10; i++)
				Console.WriteLine($"Row {i} is empty: {rowIndicies.Contains(i)}");
		}
	}
