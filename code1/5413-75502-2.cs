    static bool IsGenericEnumerable(Type t) {
        var genArgs = t.GetGenericArguments();
        if (genArgs.Length == 1 &&
            typeof(IEnumerable<>).MakeGenericType(genArgs).IsAssignableFrom(t)
        )
            return true;
        else
            return t.BaseType != null && IsGenericEnumerable(t.BaseType);
    }
