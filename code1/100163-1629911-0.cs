    protected void GetValues()
    {
    // Access to the public variable town.
        string myNewtown = publictown;
        string myNewName = publicname;
    // or
        string myNewtown = myinfo.publictown;
        string myNewName = myinfo.publicname;
    }
    protected void Setvalues()
    {
        publicname = "leo";
        publictown = "london";
    }
    // we store reference to internal object
    informations myinfo = new informations();
    // and delegate property access to its properties.
    public string publicname 
    { 
        get{ return informations.publicname;} 
        set{ informations.publicname = value; } 
    }
    public string publictown 
    { 
        get{ return informations.publictown;} 
        set{ informations.publictown = value; } 
    }
    private class informations
    {
        public string publicname { get; set; }
        public string publictown { get; set; }
    }
