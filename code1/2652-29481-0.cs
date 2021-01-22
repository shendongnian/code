    static object GetInstanceFromParameters(string typeName, params object[] pars) 
    {
        var t = Assembly.GetExecutingAssembly().GetType(typeName);
        var c = t.GetConstructor(pars.Select(p => p.GetType()).ToArray());
        if (c == null) return null;
            
        return c.Invoke(pars);
    }
