	using (ComWrapper<Excel.Application> application = new ComWrapper<Excel.Application>(new Excel.Application()))
	{
		try
		{
			using (ComWrapper<Excel.Workbooks> workbooks = new ComWrapper<Excel.Workbooks>(application.ComObject.Workbooks))
			{
				using (ComWrapper<Excel.Workbook> workbook = new ComWrapper<Excel.Workbook>(workbooks.ComObject.Open(...)))
				{
					using (ComWrapper<Excel.Worksheet> worksheet = new ComWrapper<Excel.Worksheet>(workbook.ComObject.ActiveSheet))
					{
						FillTheWorksheet(worksheet);
					}
					// Close the workbook here (see edit 2 below)
				}
			}
		}
		finally
		{
			application.ComObject.Quit();
		}
	}
