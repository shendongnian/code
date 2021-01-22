    [DllExport]
    public static int _add(int a, int b)
    {
        return a + b;
    }
    [DllExport]
    public static bool saySomething()
    {
        DialogResult dlgres = MessageBox.Show(
            "Hello from managed environment !",
            ".NET clr",
            MessageBoxButtons.OKCancel
        );
        return dlgres == DialogResult.OK;
    }
