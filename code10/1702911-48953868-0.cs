    using Excel = Microsoft.Office.Interop.Excel;
    // ... ...
	var excel = new Excel.Application();
	var workBooks = excel.Workbooks;
	var workBook = workBooks.Add();
	var workSheet = (Excel.Worksheet)excel.ActiveSheet;
				
	workSheet.Cells[1, "A"] = "Foo";
	workSheet.Cells[1, "B"] = "Bar";
    // ...
    workBook.SaveAs(Directory.GetCurrentDirectory()+"\\"+filename, Excel.XlFileFormat.xlOpenXMLWorkbook);
