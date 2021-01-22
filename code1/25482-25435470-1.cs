    [TestMethod]
    public void TestMethod1()
    {
    	HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
    	...
    }
    
    [TestMethod]
    public void TestMethod2()
    {
    	HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
    	...
    }
