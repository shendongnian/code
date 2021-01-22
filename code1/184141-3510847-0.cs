    public void Execute(Delegate action, params object[] parameters)
    {
        DoStuff();
        action.DynamicInvoke(parameters);
        DoMoreStuff();
    }
