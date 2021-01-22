    protected override System.Net.WebRequest GetWebRequest(Uri uri)
    {
      System.Net.WebRequest request = base.GetWebRequest(uri);
      request.Headers.Add("myheader", "myheader_value");
      return request;
    }
