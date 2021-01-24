     public static object displayResultInExcelFile(object[,]array)
    {
        var caller = Excel(xlfCaller) as ExcelReference;
        if (caller == null)
            return array;
        int rows = array.GetLength(0);
        int columns = array.GetLength(1);
        if (rows == 0 || columns == 0)
            return array;
        var rowLast = caller.RowFirst + rows - 1;
        var columnLast = caller.ColumnFirst + columns - 1;
        if (rowLast > ExcelDnaUtil.ExcelLimits.MaxRows - 1 ||
         columnLast > ExcelDnaUtil.ExcelLimits.MaxColumns - 1)
        {
            return ExcelError.ExcelErrorValue;
        }
        ExcelAsyncUtil.QueueAsMacro(
            delegate
            {
                var newTarget = new ExcelReference(caller.RowFirst + 1, rowLast + 1, caller.ColumnFirst, columnLast, caller.SheetId);
    Microsoft.Office.Interop.Excel.Application oxl = (Microsoft.Office.Interop.Excel.Application)Marshal.GetActiveObject("Excel.Application");
                oxl.Visible = true;               
                Workbook wrkbk = oxl.ActiveWorkbook;
                string wbkname =wrkbk.Name;
                Worksheet wrksht = wrkbk.ActiveSheet ;
                string wrksheetname = oxl.ActiveSheet.Name;               
                object cell1 = wrksht.Cells[newTarget.RowFirst+1, newTarget.ColumnFirst];
               
                object cell2 = wrksht.Cells[newTarget.RowFirst+1
                    , newTarget.ColumnLast];
                Range headerRange = wrksht.get_Range(cell1, cell2);
                wrksht.ListObjects.AddEx(XlListObjectSourceType.xlSrcRange, headerRange, Type.Missing,XlYesNoGuess.xlYes,Type.Missing).Name= "MyTableStyle";
                wrksht.ListObjects.get_Item("MyTableStyle").TableStyle = "TableStyleMedium9";
                
                newTarget.SetValue(array);
            } );
        return array;
    }
