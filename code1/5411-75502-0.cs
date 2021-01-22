    static bool IsGenericEnumerable(Type t) {
        var genArgs = t.GetGenericArguments();
        // No generic type, or too many type parameters:
        if (genArgs.Length != 1)
            return false;
        return typeof(IEnumerable<>).MakeGenericType(genArgs).IsAssignableFrom(t);
    }
