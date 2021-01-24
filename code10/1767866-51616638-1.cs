    string report = listBoxReports.SelectedItem.ToString();
    
    // create an application object.
    MsAccess.Application app = new MsAccess.Application();
    // open the access database file.
    app.OpenCurrentDatabase(textBoxAccess.Text.Trim(), false, "");
    app.Visible = false;
    // open the report
    app.DoCmd.OpenReport(report, 
        Microsoft.Office.Interop.Access.AcView.acViewPreview, Type.Missing, 
        Type.Missing, MsAccess.AcWindowMode.acWindowNormal, Type.Missing);
    // print the report to the default printer.
    app.DoCmd.PrintOut(MsAccess.AcPrintRange.acPrintAll, Type.Missing, 
        Type.Missing, MsAccess.AcPrintQuality.acHigh, Type.Missing, Type.Missing);
    // cleanup
    app.CloseCurrentDatabase();
    app = null;
