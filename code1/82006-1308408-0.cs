    public static int ParseQueryInt(string key, int defaultValue)
    {
        return ParseQuery(key, defaultValue, HttpContext.Current.Request);
    }
    public static int ParseQueryInt(string key, int defaultValue, 
                                    HttpRequest request)
    {
       NameValueCollection nvc;
       if (request.QueryString["name"] != null)
       {
          //Parse strings.
       }
    }
