How about creating a GenericIdentity and attaching that to the Thread.CurrentPrincipal in your test like so:
    [TestMethod]
    public void TestMethod1() 
    { 
        var identity = new GenericIdentity("tester");
        var roles = new[] { @"BUILTIN\Users" };
        var principal = new GenericPrincipal(identity, roles);
        Thread.CurrentPrincipal = principal;
        var c = new MyClass();
    }
