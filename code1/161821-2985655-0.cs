    static void AddOne(ref int i)
    {
        i++;
    }
    static void Main()
    {
        int foo = 7;
        AddOne(ref foo);
        Console.WriteLine(foo);
    }
