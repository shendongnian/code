    public MyClass ()
    {
        _param0 = string.Empty;
    }
    
    public MyClass (string param1) : this ()
    {
        _param1 = param1;
    }
    public MyClass (string param1, string param2) : this (param1)
    {
        _param2 = param2;
    }
