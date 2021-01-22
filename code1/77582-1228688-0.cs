    protected String ParamMethod(String sWho)
    {
        return "Hello " + sWho;
    }
    
    protected void RunMethod(Func<string> ArgMethod)
    {
        MessageBox.Show(ArgMethod());
    }
    
    protected void MyMethod()
    {
        RunMethod( () => ParamMethod("World"));
    }
