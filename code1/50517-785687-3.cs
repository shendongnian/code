    Excel.Application app = new Excel.Application();
    Excel.Workbook wb = app.Workbooks.Add(missing);
    ...
    wb.SaveAs(@"C:\temp\test.xlsx", missing, missing, missing, missing,
              missing, Excel.XlSaveAsAccessMode.xlExclusive,
              missing, missing, missing, missing, missing);
