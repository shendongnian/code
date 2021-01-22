        string s = "<prefix>" + name;	// case sensitive; Type.FullName
        Type type = Type.GetType(s);
        Object o = System.Activator.CreateInstance(type, args);
        return o;
    }
