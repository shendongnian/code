    public int? MyProperty
    {
        get
        {
            return ViewState["status"] as int?;
    
        }
        set
        {
            ViewState["status"] = value;
        }
    }
