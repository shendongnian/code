    public static void DoSomethingMethod(string[] names, Func<string, bool> myExpression)
    {
        Console.WriteLine("Lambda used to represent an anonymous method");
        foreach (var item in names)
        {
            if (myExpression(item))
                Console.WriteLine("Found {0}", item);
        }
    }
