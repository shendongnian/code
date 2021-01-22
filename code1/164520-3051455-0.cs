    using Excel = Microsoft.Office.Interop.Excel;
    (...)
    var app = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    // I have english excel, but another culture and need to use english culture to use excel calls...
    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
    app.Workbooks["DataSheet"].Close(false, false, false);
