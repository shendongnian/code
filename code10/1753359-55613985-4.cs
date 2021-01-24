    void Main()
    {
        var oExcelApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
        try{
            var WB = oExcelApp.ActiveWorkbook;
            var WS = (Worksheet)WB.ActiveSheet;
            //((string)((Range)WS.Cells[1,1]).Value).Dump("Cell Value"); //cel A1 val
            oExcelApp.Run("Compiler").Dump("macro");
        }
        finally{
            if(oExcelApp != null)
                System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcelApp);
            oExcelApp = null;
        }
    }
