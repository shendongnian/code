    public bool IsAttached(Action<string> methodToCheck)
    {
        SomeWork completed = DoWork;
        return completed.GetInvocationList().Any(m => m.Method.Name == methodToCheck.Method.Name);
    }
