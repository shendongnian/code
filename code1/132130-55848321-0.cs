    bool TryHandleDictionary(object o)
    {
        var t = o.GetType();
        if (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(Dictionary<,>)) return false;
        var m = typeof(Bar).GetMethod("Foo", BindingFlags.Public | BindingFlags.Static);
        var m1 = m.MakeGenericMethod(t.GetGenericArguments());
        m1.Invoke(null, new[] { o });
        return true;
    }
