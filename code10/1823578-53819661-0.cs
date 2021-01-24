    private object _myProperty;
    public object MyProperty
    {
       public get { return _myProperty; }
       public set
       {
          if(_myProperty == null) { _myProperty = value; }
          else { throw new InvalidOperationException("MyProperty can't be changed onece set"); }
       }
    }
