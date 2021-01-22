    class TestClass { }
    Singleton s1 = Singleton<TestClass>.Instance;
    Singleton s2 = Singleton<TestClass>.Instance;
    if (s1.Equals(s2))
    {
        Console.WriteLine("Thread-Safe Generic Singleton objects are the same");
    }
