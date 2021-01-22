    public void InvokeMethod(Action action)
    {
        action();
    }
    public int Add(int a, int b)
    {
        return a + b;
    }
    public void Test()
    {    
        InvokeMethod(() => Add(2, 3));
    }
