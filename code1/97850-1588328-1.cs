    private string _postcode = String.Empty;
    public string Postcode 
    {
        get
        {
            return  _postcode;
        }
        set
        {
            _postcode = value ?? String.Empty;
        }
    }
