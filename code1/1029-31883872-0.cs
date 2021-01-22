    public object Get( string _toparse, Type _t )
    {
        // Test for Nullable<T> and return the base type instead:
        Type undertype = Nullable.GetUnderlyingType(_t);
        Type basetype = undertype == null ? _t : undertype;
        return Convert.ChangeType(_toparse, basetype);
    }
    public T Get<T>(string _key)
    {
        return (T)Get(_key, typeof(T));
    }
    public void test()
    {
        int x = Get<int>("14");
        int? nx = Get<Nullable<int>>("14");
    }
 
