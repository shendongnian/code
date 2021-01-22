    protected delegate String MyDelegate(String str);
    protected void MyMethod()
    {
        MyDelegate del1 = new MyDelegate(ParamMethod);
        RunMethod(del1, "World");
    }
    protected void RunMethod(MyDelegate mydelegate, String s)
    {
        MessageBox.Show(mydelegate(s) );
    }
    protected String ParamMethod(String sWho)
    {
        return "Hello " + sWho;
    }
