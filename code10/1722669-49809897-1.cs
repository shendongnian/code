    public static bool iscalled()
    {
       return true;
    }
        [DllImport("ClassLibrary1.dll")]
    public static extern bool iscalled();
    public void mydllcall1()
    {
       bool ud = Class1.iscalled();
       MessageBox.Show(ud.ToString());
    }
