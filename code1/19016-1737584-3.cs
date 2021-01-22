    public string GetRequest(Uri uri, int timeoutMilliseconds)
    {
      using (var client = new WebClientWithTimeout(timeoutMilliseconds))
      {
        return client.DownloadString();
      }
    }
