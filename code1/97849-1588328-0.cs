    private string _postcode;
    public string Postcode 
    {
        get
        {
            return  _postcode ?? String.Empty;
        }
        set
        {
            _postcode = value;
        }
    }
