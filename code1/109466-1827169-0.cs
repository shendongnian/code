    private void DoSomeStuff()
    {
        var application = new Microsoft.Office.Interop.Excel.Application();
        // Do stuff ...
        CloseExcel(application);
    }
    private static void CloseExcel(Microsoft.Office.Interop.Excel.Application excel)
    {
        while (Marshal.ReleaseComObject(excel) != 0) { }
        excel = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
