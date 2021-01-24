    private void doWork()
    {
        try
        {
            doWorkImpl();
        }
        finally
        {
            GC.Collect(); //The GC collect needs to be here, after the scope of doWorkImpl ends.
            GC.WaitForPendingFinalizers(); //The excel instance gets closed in the finalizer.
        }
    }
    private void doWorkImpl()
    {
        var excelApp = new MsExcel.Application();
        var workBooks = excelApp.Workbooks;
        var workbook = excelApp.Workbooks.Add();
        var worksheet = workbook.Sheets[1]; //This needs to be a local variable, not a class variable.
        //Do Work Here
        _worksheet.SaveAs(filePath);
        workbook.Close(false,System.Reflection.Missing.Value,System.Reflection.Missing.Value);
        workBooks.Close();
        excelApp.Quit();
    }
