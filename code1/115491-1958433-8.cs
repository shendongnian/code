    // Note:
    // using System.Runtime.InteropServices;
    // using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application excelApp = 
        Marshal.GetActiveObject("Excel.Application");
    
    object activeSheet = excelApp.ActiveSheet;
