    private IDictionary<string, Action> _actions;
    public void RegisterAction(string propertyName, Action action)
    {
        _actions.Add(propertyName, action);
    }
    public void DoSomething(string propertyName)
    {
        _actions[propertyName]();
    }
