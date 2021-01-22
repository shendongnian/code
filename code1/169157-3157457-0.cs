    try
    {
        // Grab a reference to an open instance of Excel
        var oExcelApp =
            (Microsoft.Office.Interop.Excel.Application)
            Marshal.GetActiveObject("Excel.Application");
        // Loop around the workbooks to find the one you want to close
        for (int i = 1; i <= oExcelApp.Workbooks.Count; i++)
        {
            if (oExcelApp.Workbooks[i].Name == "requiredname")
                oExcelApp.Workbooks[i].Close(Type.Missing, Type.Missing, Type.Missing);
        }
        // Clear up...
        Marshal.FinalReleaseComObject(oExcelApp);
    }
    catch(Exception ex)
    {
       // Something went wrong... 
    }
