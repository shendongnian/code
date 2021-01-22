    static bool IsNullOrDefault<T>(T value)
    {
        return object.Equals(value, default(T));
    }
    
    //...
    double d = 0;
    IsNullOrDefault(d); // true
    MyClass c = null;
    IsNullOrDefault(c); // true
    
