    public static void Times(this int iterations, Action action)
    {
        for (int i = 0; i < iterations; i++)
        {
            action();
        }
    }
    ...
    6.Times(() => {
        DoSomething();
        SomeProperty = true;
    });
