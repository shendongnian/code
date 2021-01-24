    public bool MyMethod(string _type)
    {
        Type type = Type.GetType(_type);
        var dbSet = _context.Set<type>();  
        // do something with tableSet
    }
    var result = MyMethod("Namespace.MyClass, MyAssembly")
