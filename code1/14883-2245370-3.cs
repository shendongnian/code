    private MyClass _myObj;
    public MyClass MyObj {
      get {
        if (_myObj == null)
          _myObj = CreateMyObj(); // some other code to create my object
        return _myObj;
      }
    }
