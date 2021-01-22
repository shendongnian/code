    using System.Reflection;
    using Microsoft.Office.Interop.Excel;
    
    object False = false;
    object True = true;
    
    _Application excel = new Microsoft.Office.Interop.Excel.ApplicationClass();
    
    Workbook wb = excel.Workbooks._Open(@"C:\tmp\StackOverflow.xlsx",False, False,Missing.Value,Missing.Value,False,False,Missing.Value,Missing.Value,False,Missing.Value,Missing.Value,True);
    
    _Worksheet ws = (_Worksheet)wb.Worksheets[1];
    
    string from = "A1";
    string to = "B1";
    
    Range rng = ws.get_Range(from,to);
    
    Range findRng = rng.Find("Sep-08",Missing.Value,XlFindLookIn.xlValues,Missing.Value,Missing.Value,XlSearchDirection.xlNext,False,False,Missing.Value);
