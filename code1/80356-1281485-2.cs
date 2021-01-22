    [DllImport("shell32.dll", SetLastError = true)]
    static extern int SHMultiFileProperties(IDataObject pdtobj, int flags);
    public static void Foo()
    {
        var pdtobj = new DataObject();
        pdtobj.SetFileDropList(new StringCollection { @"C:\Users", @"C:\Windows" });
        if (SHMultiFileProperties(pdtobj, 0) != 0 /*S_OK*/)
        {
            throw new Win32Exception();
        }
    }
