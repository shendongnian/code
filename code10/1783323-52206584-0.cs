    //Helper function to cleanup
    public void ReleaseObject(object obj)
    {
        if (obj != null && Marshal.IsComObject(obj))
        {
            Marshal.ReleaseComObject(obj);
        }
    }
    public void CopyIntoOne(List<string> pSourceFiles, string pDestinationFile)
    {
        var sourceExcelApp = new Microsoft.Office.Interop.Excel.Application();
        var destinationExcelApp = new Microsoft.Office.Interop.Excel.Application();
        // TODO: Check if it exists
        destinationExcelApp.Workbooks.Open(pDestinationFile);
        // for debug
        //destinationExcelApp.Visible = true;
        //sourceExcelApp.Visible = true;
        int i = 0;
        var sheets = destinationExcelApp.ActiveWorkbook.Sheets;
        var lastsheet = destinationExcelApp.ActiveWorkbook.Sheets[sheets.Count];
        ReleaseObject(sheets);
        foreach (var srcFile in pSourceFiles)
        {
            sourceExcelApp.Workbooks.Open(srcFile);
            // get extends
            var lastRow = sourceExcelApp.ActiveSheet.Cells.Find("*", System.Reflection.Missing.Value,
                System.Reflection.Missing.Value, System.Reflection.Missing.Value, XlSearchOrder.xlByRows,
                XlSearchDirection.xlPrevious, false, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            var lastCol = sourceExcelApp.ActiveSheet.Cells.Find("*", System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                System.Reflection.Missing.Value, XlSearchOrder.xlByColumns, XlSearchDirection.xlPrevious, false,
                System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            var startCell = (Range) sourceExcelApp.ActiveWorkbook.ActiveSheet.Cells[1, 1];
            var endCell = (Range) sourceExcelApp.ActiveWorkbook.ActiveSheet.Cells[lastRow.Row, lastCol.Column];
            var myRange = sourceExcelApp.ActiveWorkbook.ActiveSheet.Range[startCell, endCell];
            // copy the values
            var value = myRange.Value2;
            // create sheet in new Workbook at the end                
            Worksheet newSheet = destinationExcelApp.ActiveWorkbook.Sheets.Add(After: lastsheet);
            ReleaseObject(lastsheet);
            lastsheet = newSheet;
            //its even faster when adding it at the front
            //Worksheet newSheet = destinationExcelApp.ActiveWorkbook.Sheets.Add();
            // change that to a good name
            newSheet.Name = ++i + "";
            var dstStartCell = (Range) destinationExcelApp.ActiveWorkbook.ActiveSheet.Cells[1, 1];
            var dstEndCell = (Range) destinationExcelApp.ActiveWorkbook.ActiveSheet.Cells[lastRow.Row, lastCol.Column];
            var dstRange = destinationExcelApp.ActiveWorkbook.ActiveSheet.Range[dstStartCell, dstEndCell];
            // this is the actual paste
            dstRange.Value2 = value;
            //cleanup
            ReleaseObject(startCell);
            ReleaseObject(endCell);
            ReleaseObject(myRange);
            ReleaseObject(value);// cannot hurt, but not necessary since its a simple array
            ReleaseObject(dstStartCell);
            ReleaseObject(dstEndCell);
            ReleaseObject(dstRange);
            ReleaseObject(newSheet);
            ReleaseObject(lastRow);
            ReleaseObject(lastCol);
            sourceExcelApp.ActiveWorkbook.Close(false);
        }
        ReleaseObject(lastsheet);
        sourceExcelApp.Quit();
        ReleaseObject(sourceExcelApp);
        destinationExcelApp.ActiveWorkbook.Save();
        destinationExcelApp.Quit();
        ReleaseObject(destinationExcelApp);
        destinationExcelApp = null;
        sourceExcelApp = null;
    }
