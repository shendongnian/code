    System.Web.HttpBrowserCapabilities browser = Request.Browser;
    IDictionaryEnumerator enumerator = browser.Capabilities.GetEnumerator();
    while (enumerator.MoveNext())
    {
        string key = (string)enumerator.Key.ToString();
        object value = enumerator.Value;
        Response.Write(String.Format("Key = {0}, Value = {1}",value, key));
    }
