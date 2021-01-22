    NameValueCollection fixedQueryString = new NameValueCollection();
    foreach (string key in Request.QueryString.Keys)
    {
      string value = Request.QueryString[key];
      if(value.Contains(","))
      {
         value = value.Split(',')[0];
      }
      fixedQueryString.Add(key, value);
    }
