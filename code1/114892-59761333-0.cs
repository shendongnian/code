    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application xlsApp = new Excel.Application();
    xlsApp.DisplayAlerts = false;
    Excel.Workbooks wkbs = xlsApp.Workbooks;
    Excel.Workbook wkb;
    
    
    try
    {
        wkb = wkbs.Open(path, ReadOnly: true, Password: "");
        //If you don't send a string for the password, it will popup a window
        //asking for the password and halt your program. If the workbook has no
        //password, it will open just fine.
        
    }
    catch (Exception ex)
    {
        //If the file is password protected or otherwise unreadable, it will throw an exception.
    }
    wkb.Close(false);
    xlsApp.Quit();
