    public string BuildURLAndNavigate()
    {
        var uriBuilder = new UriBuilder("http://some.com/nav/somepage.asp");
        var values = new HttpNameValueCollection();
        values.Add("app", "myapp");
        switch (codeType)
        {
            case CodeType.Series:
                values.Add("tools", "ser");
                break;
            case CodeType.DataType:
                values.Add("tools", "dt");
                break;
        }
        // You could even do things like this without breaking your urls
        values.Add("p", "http://www.example.com?p1=v1&p2=v2");
      
        string VER_NUM = "5.0";
        values.Add("vsn", VER_NUM);
        uriBuilder.Query = values.ToString();
        return uriBuilder.ToString();
    }
