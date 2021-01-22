    [Test]
    public void Test()
    {
      ShouldPass("rinat.abdullin@lokad.com", "pwd", "http://ws.lokad.com/TimeSerieS2.asmx");
      ShouldPass("some@nowhere.net", "pwd", "http://127.0.0.1/TimeSerieS2.asmx");
      ShouldPass("rinat.abdullin@lokad.com", "pwd", "http://sandbox-ws.lokad.com/TimeSerieS2.asmx");
    
      ShouldFail("invalid", "pwd", "http://ws.lokad.com/TimeSerieS.asmx");
      ShouldFail("rinat.abdullin@lokad.com", "pwd", "http://identity-theift.com/TimeSerieS2.asmx");
    }
    
    static void ShouldFail(string username, string pwd, string url)
    {
      try
      {
        ShouldPass(username, pwd, url);
        Assert.Fail("Expected {0}", typeof (RuleException).Name);
      }
      catch (RuleException)
      {
      }
    }
    
    static void ShouldPass(string username, string pwd, string url)
    {
      var connection = new ServiceConnection(username, pwd, new Uri(url));
      Enforce.That(connection, ApiRules.ValidConnection);
    }
