    List<object> caches;
    foreach (object obj in caches)
    {
        Type t = obj.GetType();
        MethodInfo m = t.GetMethod("Clear");
    
        // Object does not have a public instance method named "Clear"
        if (m == null) { continue; }
    
        m.Invoke(obj, new object[0]);
    }
