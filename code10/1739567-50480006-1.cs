    using Microsoft.Office.Interop.Excel;
    string path          = "C:\\Test.xlsx ";
    Application excel    = new Application();
    Workbook wb          = excel.Workbooks.Open(path);
    Worksheet excelSheet = wb.ActiveSheet;
    // Read the second row second column cell
    string test = excelSheet.Cells[2, 2].Value.ToString();
    string splittedString = test.Split('\n');
