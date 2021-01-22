    public FooParent CreateFoo(string name)
    {
        if (name == null)
        {
            throw new ArgumentNullException("name");
        }
        string fullName = "Some.NameSpace." + name;
        // This is assuming that the type will be in the same assembly
        // as the call. If that's not the case, we can look at that later.
        Type type = Type.GetType(fullName);
        if (type == null)
        {
            throw new ArgumentException("No such type: " + type);
        }
        if (!typeof(FooParent).IsAssignableFrom(type))
        {
            throw new ArgumentException("Type " + type +
                                        " is not compatible with FooParent.");
        }
        return (FooParent) Activator.CreateInstance(type);
    }
