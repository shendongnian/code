    private void NAR(object o)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.FinalReleaseComObject(o);
        }
        catch { }
        finally
        {
            o = null;
        }
    }
