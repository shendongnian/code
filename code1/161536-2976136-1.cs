    ExecuteIgnore(o1.Update);
    ExecuteIgnore(o2.Update);
    ExecuteIgnore(o3.Update);
    ...
    private static void ExecuteIgnore(Action action)
    {
        try { action(); }
        catch(Exceptions.NoChangeMade) { }
    }
