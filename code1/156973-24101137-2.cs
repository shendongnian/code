    public static void TestProxies() {
      var lowp = new List<WebProxy> { new WebProxy("1.2.3.4", 8080), new WebProxy("5.6.7.8", 80) };
      Parallel.ForEach(lowp, wp => {
        var success = false;
        var errorMsg = "";
        var sw = new Stopwatch();
        try {
          sw.Start();
          var response = new RestClient {
            BaseUrl = "https://webapi.theproxisright.com/",
            Proxy = wp
          }.Execute(new RestRequest {
            Resource = "api/ip",
            Method = Method.GET,
            Timeout = 10000,
            RequestFormat = DataFormat.Json
          });
          if (response.ErrorException != null) {
            throw response.ErrorException;
          }
          success = (response.Content == wp.Address.Host);
        } catch (Exception ex) {
          errorMsg = ex.Message;
        } finally {
          sw.Stop();
          Console.WriteLine("Success:" + success.ToString() + "|Connection Time:" + sw.Elapsed.TotalSeconds + "|ErrorMsg" + errorMsg);
        }
      });
    }
