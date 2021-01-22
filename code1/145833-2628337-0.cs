    void doSomething(object obj)
    {
        Type type = obj.GetType();
        foreach(MemberInfo mi in type.GetMembers())
        {
            //print the data or work on it.
        }
    }
