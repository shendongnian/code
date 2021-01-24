    void Main()
    {
    
    	Microsoft.Office.Interop.Excel.Application app;
    	Microsoft.Office.Interop.Excel.Workbook wkb;
    	app = new Microsoft.Office.Interop.Excel.Application();
    	wkb = app.Workbooks.Open(@"e:\temp\test.xlsx");
    	int row = GetLastRow(wkb, "sheet1", "A");
    	Console.WriteLine(row);
    	app.Quit();
    }
    
    int GetLastRow(Workbook wkb, string sheet, string column)
    {
    	Microsoft.Office.Interop.Excel.Worksheet sht = wkb.Worksheets[sheet] as Worksheet;
    	Microsoft.Office.Interop.Excel.Range range = sht.Range[column + ":" + column];
    	range = range.Cells[range.Rows.Count, range.Column] as Range;
    	return range.End[XlDirection.xlUp].Row;
    }
