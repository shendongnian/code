    public Person(string name) : this(name, string.Empty)
    {
    }
    public Person(string name, string address) : this(name, address, string.Empty)
    {
    }
    public Person(string name, string address, string postcode)
    {
        this.Name = name;
        this.Address = address;
        this.Postcode = postcode;
    }
