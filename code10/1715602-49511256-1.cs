    public String URL 
    {
        get
        {
            return this.Uri.AbsoluteUri;
        }
        set
        {
            this.Uri = new Uri(value);
        }
     }
