    [TestMethod]
    public void Test()
    {   
        bool running = true;
        string result = null;
     
        Action<string> cb = name =>
        {
            result = name;
            running = false;
        };
        
        var d = new MyClass();
        d.Get("test", cb);
        while(running)
        {
            Thread.Sleep(100);
        }
        Assert.IsNotNull(result);
    }
