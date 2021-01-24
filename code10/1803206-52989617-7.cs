    public static void Action1(Action<int> foo)
    {
        if (foo != null)
            foo(10);
    }
    
    public static void Action2(Action<int> foo)
    {
        foo?.Invoke(10);
    }
