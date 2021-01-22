    void RunFromHere()
    {
        string param1 = "hello";
        int param2 = 42;
    
        Thread thread = new Thread(delegate()
        {
            MyParametrizedMethod(param1,param2);
        });
        thread.Start();
    }
    
    void MyParametrizedMethod(string p,int i)
    {
    // some code.
    }
