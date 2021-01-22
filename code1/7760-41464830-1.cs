    [TestMethod]
    public void TestMyService()
    {
        MyService fs = new MyService();
    
        var OnStart = fs.GetType().BaseType.GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
    
        OnStart.Invoke(fs, new object[] { null });
    }
    // As an extension method
    public static void Start(this ServiceBase service, List<string> parameters)
    {
         string[] par = parameters == null ? null : parameters.ToArray();
         var OnStart = service.GetType().GetMethod("OnStart", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
         OnStart.Invoke(service, new object[] { par });
    }
