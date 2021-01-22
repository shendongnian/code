    public string Bar
    {
        get { return bar; }
        set { bar = HttpUtility.HtmlEncode(value); }
    }
    public string UnsafeBar
    {
        get { return HttpUtility.HtmlDecode(value); }
    }
