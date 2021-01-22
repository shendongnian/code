    public string VIN
    {
        get { return _vin; }
        set
        {
          if (value.Length != 17) 
            throw new ArgumentOutOfRangeException("VIN", "VIN must be 17 characters"); 
          else
            _vin = value;
        }
    }
