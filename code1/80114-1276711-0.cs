    Excel.ApplicationClass objExcelApp = new Excel.ApplicationClass();
    Excel.Workbook objWorkbook = objExcelApp.Workbooks.Open("File Name",0, true, 1, "", "", true, Excel.XlPlatform.xlWindows,Type.Missing, false, false, 0,true);
    Excel.Worksheet objWorksheet = (Excel.Worksheet) objWorkbook.Worksheets.get_Item(1);
    Excel.Range objRangeData =objWorksheet.UsedRange;
    // Some proces
    GC.Collect();
    objRangeData.Clear ();
    objWorkbook.Close(false, strDictFile, false);
    objExcelApp.Workbooks.Close();
    objExcelApp.Quit();				
    System.Runtime.InteropServices.Marshal.ReleaseComObject(objRangeData); 
    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWorksheet);			
    System.Runtime.InteropServices.Marshal.ReleaseComObject(objWorkbook); System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcelApp); 
    objWorksheet = null; 
    objWorkbook = null; 
    objExcelApp = null; 
    GC.Collect(); 
    GC.WaitForPendingFinalizers();
