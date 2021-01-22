    public void CreateInstanceOfType(Type t)
    {
        var instance = Activator.CreateInstance(t); // create instance
    
        // set property on the instance
        t.InvokeMember(
            "foo", // property name
            BindingFlags.SetProperty,
            null,
            obj,
            new Object[] { "bar" } // property value
        );
    }
