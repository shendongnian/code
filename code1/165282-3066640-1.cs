    Excel.Application oXL;
    Excel._Workbook oWB;
    Excel._Worksheet oSheet;
         
    //Start Excel and get Application object.
    oXL = new Excel.Application();
    oXL.Visible = false;
    oXL.DisplayAlerts = false; // prevents message from popping up
    try
    {
        //Get a new workbook.
        oWB = (Excel._Workbook)(oXL.Workbooks.Open(filename, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing));
        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        int nCounter = 1;
        oSheet.Copy(oSheet, Type.Missing);
        Excel._Worksheet oSheetGame = (Excel._Worksheet)oWB.Worksheets["MyTemplate"];
        oSheetGame.Name = "MyNewWorksheetName";
        // do something with worksheet
 
        ((Excel._Worksheet)oWB.Sheets["MyTemplate"]).Delete(); // delete template
        ((Excel._Worksheet)oWB.Worksheets["MyNewWorksheetName"]).Activate();
    }
    catch (Exception e)
    {
        //throw e;
        throw;
    }
    finally
    {
        //Make sure Excel is visible and give the user control
        //of Microsoft Excel's lifetime.
        oXL.Visible = true;
        oXL.UserControl = true;
    }
    oXL.Save(Type.Missing);
