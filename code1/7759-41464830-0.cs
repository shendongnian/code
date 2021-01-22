    [TestMethod]
    public void TestMyService()
    {
        MyService fs = new MyService();
    
        var OnStart = fs.GetType().BaseType.GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    
        OnStart.Invoke(fs, new object[] { null });
    }
