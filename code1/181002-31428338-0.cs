    using InteropExcel = Microsoft.Office.Interop.Excel;
    var Excel = new InteropExcel.Application ();
    
    // Disables macros.
    Excel.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
    
    var MyWorkbook = Excel.Workbooks.Open (@"YourFilePath");
    var FirstWorksheet = (InteropExcel.Worksheet)MyWorkbook.Worksheets ["Plan1"];
    var MyCell = ((InteropExcel.Range)FirstWorksheet.Cells [1,1]);
    var CellValue = (Int32)MyCell.Value;
