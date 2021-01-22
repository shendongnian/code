    [DllImport("shell32.dll", SetLastError = true)]
    static extern bool SHMultiFileProperties(IDataObject pdtobj, int flags);
    public static void Foo()
    {
        var pdtobj = new DataObject();
        // set data
        if (!SHMultiFileProperties(pdtobj, 0))
        {
            throw new Win32Exception();
        }
    }
