    public void Call()
    {
        DoSomething(new Action(() => Console.WriteLine("Arrived")));
    }
    
    public void DoSomething(Action obj)
    {
        int x = 0; // Nothing printed yet
        Action storedAction = obj; // Nothing printed yet
        storedAction.Invoke(); // Message will be printed
    }
