    [DllImport("SomeDLL.dll")]
    public extern static void SomeFunction();
    [DllImport("SomeDLL.dll")]
    public extern static string GetError();
    SomeFunction();
    string Error = GetError();
    if(String.IsNullOrEmpty(Error)==true)
    {
        //The processing was successfull
    }
    else
    {
        //The processing was unsuccessful
        MessageBox.Show(Error);
    }
