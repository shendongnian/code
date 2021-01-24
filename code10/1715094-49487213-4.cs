    [DllImport("kernel32.dll")]
    public static extern IntPtr LoadLibrary(string dllToLoad);
    [DllImport("user32.dll")]
    public static extern IntPtr LoadCursor(IntPtr hInstance, UInt16 lpCursorName);
    private void button1_Click(object sender, EventArgs e)
    {
        var l = LoadLibrary("ole32.dll");
        var h = LoadCursor(l, 6);
        this.Cursor = new Cursor(h);
    }
