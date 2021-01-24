    Microsoft.Office.Interop.Excel.Application app;
    Microsoft.Office.Interop.Excel.Workbook wkb; 
    void Main()
    {
    
    	app = new Microsoft.Office.Interop.Excel.Application();
    	wkb = app.Workbooks.Open(@"e:\temp\test.xlsx");
    	int row = GetLastRow("sheet1", "A");
    	Console.WriteLine(row);
    	app.Quit();
    }
    
    int GetLastRow(string sheet, string column)
    {
        Microsoft.Office.Interop.Excel.Worksheet sht = wkb.Worksheets[sheet] as Worksheet;
    	Microsoft.Office.Interop.Excel.Range range = sht.Range[column + ":" + column];
        range = range.Cells[range.Rows.Count, range.Column] as Range;
    	return range.End[XlDirection.xlUp].Row;
    }
