    Excel.Application excelApp = new Excel.Application();    
    Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
    
    workbook.SaveAs(
        "MyWorkbook", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
         Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, 
         Type.Missing, Type.Missing);
