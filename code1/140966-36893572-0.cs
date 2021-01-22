    public MyType MyProperty 
    {
      get
      {
        if (_myProperty == null)
            _myProperty == XYZ;
        return _myProperty;
      }
      set
      {
        if(value == null)
            throw InvalidArgumentException();
        _myProperty = value;
      }
    }
