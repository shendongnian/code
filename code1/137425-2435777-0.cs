    public void DoSomething(params string[] values)
    {
        foreach (string value in values)
            Console.WriteLine(value);
    }
