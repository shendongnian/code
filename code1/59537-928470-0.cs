    public string SessionValue(string key)
    {
        if (HttpContext.Current.Session[key] == null)
            return null;
        string result = HttpContext.Current.Session[key].ToString();
        return (result == "") ? null : result;
    }
