    Excel.Application xl = new Excel.ApplicationClass();
     
    Excel.Workbook wb = xl.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorkshe et);
     
    Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
     
    ws.Cells[1,1] = "Testing";
     
    Excel.Range range = ws.get_Range(ws.Cells[1,1],ws.Cells[1,2]);
     
    range.Merge(true);
     
    range.Interior.ColorIndex =36;
     
    xl.Visible =true;
