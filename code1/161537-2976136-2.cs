    ExecuteIgnore<Exceptions.NoChangeMade>(o1.Update);
    ExecuteIgnore<Exceptions.NoChangeMade>(o2.Update);
    ExecuteIgnore<Exceptions.NoChangeMade>(o3.Update);
    ...
    public static void ExecuteIgnore<T>(Action action) where T : Exception
    {
        try { action(); }
        catch(T) { }
    }
