    [DllImport("ClassLibrary1.dll")]
    public static extern bool iscalled();
    public void mydllcall1()
    {          
       Class1 objClass=new Class1();
       bool ud = objClass.iscalled();
       MessageBox.Show(ud.ToString());
    }
