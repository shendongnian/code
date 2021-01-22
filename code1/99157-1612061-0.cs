    public Uri Url
    {
        get
        {
            return new Uri(_url);
        }
        set
        {
            _url = value.AbsoluteUri;
        }
    }
    [Column(Name = "Url", DbType = "nvarchar(255)")]
    private string _url;
