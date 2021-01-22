    try
    {
    	System.Runtime.InteropServices.Marshal.FinalReleaseComObject(pIFuncs);
    }
    catch (System.Exception ex)
    {
    	// Do nothing
    }
    finally
    {
    	pIFuncs = null;
    }
