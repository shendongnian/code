    static void Test<T>() where T : new()
    {
        T x = new T();
        if (x == null) Console.WriteLine("wtf?");
    }
    static void Main()
    {
        Test<int?>();
    }
