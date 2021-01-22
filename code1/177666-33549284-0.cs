    private void InitialiseExcel()
    {
        if (excelApp == null)
            excelApp = new Excel.Application();
        // Turn off User Prompts
        excelApp.DisplayAlerts = false;
        // Turn off screen updating so we do not get flicker
        var app = excelApp.Application;
        app.ScreenUpdating = false;
        // Specifies the state of the window;
        excelApp.WindowState = Excel.XlWindowState.xlMinimized;
        Marshal.ReleaseComObject(app);
    }
