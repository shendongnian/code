    private object _obj;
    public object Obj
    {
      get
      {
        if(_obj == null)
        {
          _obj = new object();
        }
        return _obj;
      }
      set
      {
        if(value == badvalue)
        {
          throw new ArgumentException("value");
        }
        _obj = value;
      }
    }
