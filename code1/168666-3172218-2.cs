    public static void Main()
    {
        var someUtil = (SomeUtil)ContextRegistry.GetContext()["SomeUtil"];
        someUtil.DoSomething();
    }
