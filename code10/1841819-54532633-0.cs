    [TestCase("www.google.com")]
    [TestCase("www.yahoo.com")]
    [TestCase("www.facebook.com")]
    public void WebPageTest(string site)
    {
      driver.Url(site);
      //continue with the test.
    }
