    [TestInitialize]
        public void TestInit()
        {
          HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
        }
