    public static class WebApiConfig
    {
      public static void Register(HttpConfiguration http)
      {
        http.Formatters.Add(new PlainTextMediaTypeFormatter());
      }
    }
