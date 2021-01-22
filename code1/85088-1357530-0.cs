    Excel.Application excelApp = new Excel.Application();
    
    string versionName = excelApp.Version;
    int length = versionName.IndexOf('.');
    versionName = versionName.Substring(0, length);
    
    // int.parse needs to be done using US Culture.
    int versionNumber = int.Parse(versionName, CultureInfo.GetCultureInfo("en-US"));
    
    if (versionNumber >= 12)
    {
        // Excel 2007 or above.
    }
    else
    {
        // Excel 2003 or below.
    }
