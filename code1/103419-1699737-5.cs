    // Need all following code to clean up and extingush all references!!!
    theWorkbook.Close(null,null,null);
    xl.Workbooks.Close();
    xl.Quit();
    System.Runtime.InteropServices.Marshal.ReleaseComObject (range);
    System.Runtime.InteropServices.Marshal.ReleaseComObject (sheets);
    System.Runtime.InteropServices.Marshal.ReleaseComObject (xl);
    System.Runtime.InteropServices.Marshal.ReleaseComObject (worksheet);
    System.Runtime.InteropServices.Marshal.ReleaseComObject (theWorkbook);
    worksheet=null;
    sheets=null;
    theWorkbook=null;
    xl = null;
    GC.Collect(); // force final cleanup!
