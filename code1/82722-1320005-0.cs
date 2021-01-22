    MyMethod(new { Key1 = "value1", Key2 = "value2" });
    public void MyMethod(object keyValuePairs)
    {
        var dic = DictionaryFromAnonymousObject(keyValuePairs);
        // Do something with the dictionary
    }
    
    public static IDictionary<string, string> DictionaryFromAnonymousObject(object o)
    {
        IDictionary<string, string> dic = new Dictionary<string, string>();
        var properties = o.GetType().GetProperties();
        foreach (PropertyInfo prop in properties)
        {
            dic.Add(prop.Name, prop.GetValue(o, null) as string);
        }
        return dic;
    }
