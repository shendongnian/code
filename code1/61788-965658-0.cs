    //1 - First preference
    public void Add(BigFoo item) { Console.WriteLine("static BigFoo type Add"); }
    //2 - Second Preference
    public void Add<T>(T item) { Console.WriteLine("Generic Add");  }
    //3 - Third preferences
    public void Add(IFoo item) { Console.WriteLine("static IFoo interface Add"); }
    //4 - Compiles if 1-4 exist. Compile error (ambiguity) if only 3-4 exist. Compile error (cannot convert int to IFoo) if only 4 exists
    public void Add<T>(IEnumerable<T> group) where T : IFoo { }
