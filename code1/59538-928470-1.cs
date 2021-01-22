    public string SessionValue(string key)
    {
        object value = HttpContext.Current.Session[key];
        return (value == null) ? null : value.ToString();
    }
