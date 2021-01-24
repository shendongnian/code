    string rangeDesignation = "A1:B1,C1:D1,E1:F1";
    string listSeparator = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator;
    if (listSeparator != ",")
    {
        rangeDesignation = rangeDesignation.Replace(",", listSeparator);
    }
    Excel.Range range = Globals.ThisAddIn.Application.ActiveSheet.Range[rangeDesignation];
