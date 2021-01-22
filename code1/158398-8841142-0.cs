    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xlApp = new Excel.ApplicationClass();
    Excel.Workbook WB = xlApp.Workbooks.Add(Type.Missing);
    Excel.Worksheet WS = WB.Sheets[1] as Excel.Worksheet;
    Excel.Range r = WS.Range["A1:D10"];
    var obj = r.Value[Excel.XlRangeValueDataType.xlRangeValueMSPersistXML];
    r.Value = obj;
