    static bool foo(int input)
    {
        return input > 5;
    }
    static bool foo(string input)
    {
        return input.Length > 5;
    }
    static void baz(int input)
    {
        Console.WriteLine(input);
    }
    static void baz(string input)
    {
        Console.WriteLine(input);
    }
    static bool foo<T>(T input)
    {
        if (input is int) return foo((int)(object)input);
        if (input is string) return foo((string)(object)input);
        return false;
    }
    static void baz<T>(T input)
    {
        if (input is int) baz((int)(object)input);
        else if (input is string) baz((string)(object)input);
        else throw new NotImplementedException();
    }
    static void g<T>(T input)
    {
        if (foo(input))
            baz(input);
    }
    static void g<T, U>(T input, U inputU)
    {
        g(input);
        g(inputU);
    }
