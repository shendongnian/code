    [ClassInitialize]
    public static void ClassInit(TestContext testContext)
    {
    	HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
    }
