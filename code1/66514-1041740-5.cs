    GC.Collect();
    GC.WaitForPendingFinalizers();
    
    if (wSheet != null)
    {
        Marshal.FinalReleaseComObject(wSheet)
    }
    if (wBook != null)
    {
        wBook.Close(false, m_objOpt, m_objOpt);
        Marshal.FinalReleaseComObject(wBook);
    }
    xl.Quit();
    Marshal.FinalReleaseComObject(xl);
