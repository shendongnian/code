    public IPAddress Address
    {
        get
        {
            return address;
        }
        set
        {
            if(value == null)
            {
                throw new ArgumentNullException("value");
            }
            address = value;
        }
    }
