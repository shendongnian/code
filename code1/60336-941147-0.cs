    protected override string[] Headers {
        get { return headers; } // Note that get is protected
        set { headers = value; }
    }
    internal SetHeadersInternal(string[] newHeaders)
    {
        headers = newHeaders;
    }
