    public void DoSomething(string parameterA, int parameterB)
    {
    
    }
    
    var func = (Action)(() => DoSomething("someValue", 5));
    func();
