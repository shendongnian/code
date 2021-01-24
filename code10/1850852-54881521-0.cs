    try 
    {
        ....
        XWbook.Save();
        XWbook.Close(Type.Missing,Type.Missing,Type.Missing);
        Xcel.Quit();
    }
    finally 
    {
        Marshal.ReleaseComObject(Sh1 );
        Marshal.ReleaseComObject(XWbook);
        Marshal.ReleaseComObject(xlApp);
        Xcel= null;
    }
