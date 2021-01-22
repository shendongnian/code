    public MyClass MyProperty { get; private set; }
    
    private MyClass _myOtherProperty = new MyClass();
    public MyClass MyOtherProperty
    {
        get
        {
            return _myOtherProperty;
        }
        set
        {
            _myOtherProperty = value;
        }
    }
