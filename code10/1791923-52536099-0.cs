    public void func1()
    {
        ...
        button.Tag = new ParametersWrapper(arg1, arg2);
    }
    
    void DeleteActionHandler(object s, EventArgs e)
    {
       var args = (ParametersWrapper)((Button)sender).Tag;
    }
