    public object TryResolve(Type type)
    {
        object resolved;
        try
        {
            resolved = Resolve(type);
        }
        catch
        {
            resolved = null;
        }
        return resolved;
    }
