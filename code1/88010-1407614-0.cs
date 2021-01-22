    Type t = someInstance.getType();
    
    foreach (MemberInfo mi in t.GetMembers())
    {
        if (mi.MemberType == MemberTypes.Property)
        {
            Console.WriteLine(mi.Name);
        }
    }
