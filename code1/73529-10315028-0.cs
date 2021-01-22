    using Microsoft.Office.Interop.Excel;
    
    string filename = "C:\\romil.xlsx";
    
    object missing = System.Reflection.Missing.Value;
    
    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
    
    Microsoft.Office.Interop.Excel.Workbook wb =excel.Workbooks.Open(filename,  missing,  missing,  missing,  missing,missing,  missing,  missing,  missing,  missing,  missing,  missing,  missing,  missing,  missing);
    
    ArrayList sheetname = new ArrayList();
    
    foreach (Microsoft.Office.Interop.Excel.Worksheet  sheet in wb.Sheets)
    {
    	sheetname.Add(sheet.Name);
    }
