    [TestMethod]
    [ExpectedException(typeof(SecurityException))] // Or whatever it's called in MsTest
    public void TestMethod1() 
    { 
        var identity = new GenericIdentity("tester");
        var roles = new[] { @"BUILTIN\NotUsers" };
        var principal = new GenericPrincipal(identity, roles);
        Thread.CurrentPrincipal = principal;
        var c = new MyClass();
    }
