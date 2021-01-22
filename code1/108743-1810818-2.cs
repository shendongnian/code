    static void Main(string[] args)
    {
        DummyClass x = new DummyClass();
        string username = x.ClassName;
        DoSomething(ref username);
    }
