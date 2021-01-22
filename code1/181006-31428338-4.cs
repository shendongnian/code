    using InteropExcel = Microsoft.Office.Interop.Excel;
    var Excel = new InteropExcel.Application ();
    
    // Excel window will NOT popup if macro errors are found but
    // exceptions might be raised when you execute the broken
    // macro.
    Excel.VBE.MainWindow.Visible = false;
    // Uncomment to disable macros completely.
    // Excel.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
    // I used this snippet to open a file with a broken macro.
    var MyWorkbook = Excel.Workbooks.Open (@"YourFilePath");
    var FirstWorksheet = (InteropExcel.Worksheet)MyWorkbook.Worksheets ["Plan1"];
    var MyCell = ((InteropExcel.Range)FirstWorksheet.Cells [1,1]);
    var CellValue = (Int32)MyCell.Value;
