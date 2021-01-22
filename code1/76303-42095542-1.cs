    public CarType MyProperty
    {
        get { return Get<CarType>(); }
        set { Set(value); }
    }
    public T Get<T>([CallerMemberName]string name = null)
    {
        return (T)this[name];
    }   
    public void Set<T>(T value, [CallerMemberName]string name = null)
    {
        this[name] = value;
    }  
