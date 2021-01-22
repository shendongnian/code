    //	Creates and initializes a new object from its name and parameters
    public Object CreateObjectByName(string name, params Object[] args)
    {
        string s = "<prefix>" + name;	// case sensitive; Type.FullName
        Type type = Type.GetType(s);
        Object o = System.Activator.CreateInstance(type, args);
        return o;
    }
