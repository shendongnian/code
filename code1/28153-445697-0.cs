    private void calculateFields(){
      if (_b != INIT_VALUE && _c != INIT_VALUE)
         _a =  _c / _b;
      if (_a != INIT_VALUE && _c != INIT_VALUE)
         _b = _c / _a;
      if (_a != INIT_VALUE && _b != INIT_VALUE)
         _c = _a * _b;
    }
    
    public double A
    {
    get{
            return _a;
      }
    set{
       _a = value;
       calculateFields();
    }
    }
