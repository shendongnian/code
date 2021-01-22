    //tradition 
    private T _value; 
    public T Value 
    { 
        get 
        {
            return _value;
        }
    }
    //locally, _value can always be set
    
    //Auto-matically implemented property
    public T Value { get; }
    //there is never a way to set it
    //with this it can be privately set, but is get only to everyone else
    public T Value{ get; private set; }
