    public static void DESTROY(object o)
    {
        try {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
        }
        catch (Exception ex) {
            Debug.Fail(ex.ToString);
            ErrorLog.Write(ex.ToString);
        }
        finally {
            o = null;
        }
    }
