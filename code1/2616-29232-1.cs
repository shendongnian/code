    Microsoft.Office.Interop.Excel.Workbook wbk = excelApplication.Workbooks[0];  //or some other way of obtaining this workbook reference, as Jason Z mentioned
    wbk.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, 
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
				Type.Missing);
    wbk.Close();
    excelApplication.Quit();
    
