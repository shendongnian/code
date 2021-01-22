    // First Get The Method Used by Request i.e Get/POST from current Context
    string method = context.Request.HttpMethod;
    
    // Declare a NameValueCollection Pair to store QueryString parameters from Web Request
    NameValueCollection queryStringNameValCollection = new NameValueCollection();
    
    if (method.ToLower().Equals("post")) // Web Request Method is Post
    {
       string contenttype = context.Request.ContentType;
    
       if (contenttype.ToLower().Equals("application/x-www-form-urlencoded"))
       {
          int data = context.Request.ContentLength;
          byte[] bytData = context.Request.BinaryRead(context.Request.ContentLength);
          queryStringNameValCollection = context.Request.Params;
       }
    }
    else // Web Request Method is Get
    {
       queryStringNameValCollection = context.Request.QueryString;
    }
    
    // Now Finally if you want all the KEYS from QueryString in ArrayList
    ArrayList arrListKeys = new ArrayList();
    
    for (int index = 0; index < queryStringNameValCollection.Count; index++)
    {
       string key = queryStringNameValCollection.GetKey(index);
       if (!string.IsNullOrEmpty(key))
       {
          arrListKeys.Add(key.ToLower());
       }
    }
