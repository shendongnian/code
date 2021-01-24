    [Test]
    public void TestDraft()
    {
        StringBuilder sb = new StringBuilder(256)
        c_meth("prpr", sb, 256);
        Console.WriteLine(sb.ToString());
    }
    
    [DllImport("/home/roroco/Dropbox/cs/App.Switcher/c/app-switcher/lib/libapp-switcher-t.so")]
    private static extern void c_meth(string strArg, StringBuilder outbuf, int outsize);
