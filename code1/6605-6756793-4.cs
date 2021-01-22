    Singleton s1 = Singleton.Instance;
    Singleton s2 = Singleton.Instance;
    if (s1.Equals(s2))
    {
        Console.WriteLine("Thread-Safe Singleton objects are the same");
    }
