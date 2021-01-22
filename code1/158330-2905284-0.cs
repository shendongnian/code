    public object this[string propertyName]
    {
        get
        {
            if(propertyName == "Reference")
                return this.Reference;
            else
                return null;
        }
        set
        {
            if(propertyName == "Reference")
                this.Reference = value;
            else
                // do error case here            
        }
    }
