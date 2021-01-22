    Dictionary<string, object> dict = 
           foo.GetType()
              .GetProperties()
              .ToDictionary(pi => pi.Name, pi => pi.GetValue(foo, null));
    
    NameValueCollection nvc = new NameValueCollection();
    foreach (KeyValuePair<string, object> item in dict)
    {
       nvc.Add(item.Key, item.Value.ToString());
    }
