    public int MyFunction(MyType t)
    {
       return t.Value;
    }
    Console.WriteLine(MyFunction(t));
    t.Value++;
    Console.WriteLine(MyFunction(t));
