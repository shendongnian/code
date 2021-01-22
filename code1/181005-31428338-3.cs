    using InteropExcel = Microsoft.Office.Interop.Excel;
    var Excel = new InteropExcel.Application ();
    
    // Disables macros.
    //Excel.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
    // The editor is never shown even if errors are found.
    Excel.VBE.MainWindow.Visible = false;
    
    var MyWorkbook = Excel.Workbooks.Open (@"YourFilePath");
    var FirstWorksheet = (InteropExcel.Worksheet)MyWorkbook.Worksheets ["Plan1"];
    var MyCell = ((InteropExcel.Range)FirstWorksheet.Cells [1,1]);
    var CellValue = (Int32)MyCell.Value;
