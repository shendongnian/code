    [DllImport("shell32.dll", SetLastError = true)]
    static extern int SHMultiFileProperties(IDataObject pdtobj, int flags);
    public static void Foo()
    {
        var pdtobj = new DataObject();
        // set data
        if (SHMultiFileProperties(pdtobj, 0) != 0 /*S_OK*/)
        {
            throw new Win32Exception();
        }
    }
