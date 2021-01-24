    private Address _address;
    public Address Address
    {
      get { return _address; }
    }
    
    public ABC() //Constructor 
    {
      _address = GetAddress();
    }
