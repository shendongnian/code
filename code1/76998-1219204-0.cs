    public delegate void DelegateType();
    public static IEnumerable< DelegateType > GetStatements()
    {
        // ---- replace with your code below ----
        yield return delegate() { Console.WriteLine("statement 1"); };
        yield return delegate() { Console.WriteLine("statement 2"); };
        yield return delegate() { Console.WriteLine("statement 3"); };
        yield return delegate() 
        { 
            // You can return multiples lines in one "statement," too.
            Console.WriteLine("statement 4"); 
            Console.WriteLine("statement 5");
        };
    }
