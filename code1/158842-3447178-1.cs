    Microsoft.Office.Interop.Excel.Application tExcel = new Application();
    CultureInfo cSystemCulture = Thread.CurrentThread.CurrentCulture;
    CultureInfo cExcelCulture = new CultureInfo(tExcel.LanguageSettings.get_LanguageID(
        Microsoft.Office.Core.MsoAppLanguageID.msoLanguageIDUI));
    try
    {
        Thread.CurrentThread.CurrentCulture = cExcelCulture;
        double tVersion;
        bool tParseSucceded = double.TryParse(tExcel.Version, out tVersion);
        // 12 is the first version with .xlsx extension
        if (tVersion > 11.5)
            cDefaultExtension = ".xlsx";
        else
            cDefaultExtension = ".xls";
    }
    catch (Exception aException)
    {
        cLogger.Debug("error retrieving excel version.", aException);
        cLogger.Error("error retrieving excel version.");
    }
    finally
    {
        Thread.CurrentThread.CurrentCulture = cSystemCulture;
    }
