    public static class MyInterfaceSingleton
    {
        static MyInterfaceSingleton()
        {
            Instance = MyInterfaceFactory.CreateMyInterface();
        }
        public static IMyInterface Instance { get; private set; }
        // In C# 7, you can use just this instead:
        // public static IMyInterface Instance { get; } = MyInterfaceFactory.CreateMyInterface();
    }
