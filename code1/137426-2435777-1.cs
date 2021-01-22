    public void DoSomething(int someValue, params string[] values)
    {
        foreach (string value in values)
            Console.WriteLine(value);
    }
