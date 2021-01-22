    delegate void Del(string s);
    
    class TestClass
    {
        static void Hello(string s)
        {
            System.Console.WriteLine("  Hello, {0}!", s);
        }
    
        static void Goodbye(string s)
        {
            System.Console.WriteLine("  Goodbye, {0}!", s);
        }
    
        static void Main()
        {
            Del a, b, c, d;
    
            // Create the delegate object a that references 
            // the method Hello:
            a = Hello;
    
            // Create the delegate object b that references 
            // the method Goodbye:
            b = Goodbye;
    
            // The two delegates, a and b, are composed to form c: 
            c = a + b;
    
            // Remove a from the composed delegate, leaving d, 
            // which calls only the method Goodbye:
            d = c - a;
    
            System.Console.WriteLine("Invoking delegate a:");
            a("A");
            System.Console.WriteLine("Invoking delegate b:");
            b("B");
            System.Console.WriteLine("Invoking delegate c:");
            c("C");
            System.Console.WriteLine("Invoking delegate d:");
            d("D");
        }
    }
    /* Output:
    Invoking delegate a:
      Hello, A!
    Invoking delegate b:
      Goodbye, B!
    Invoking delegate c:
      Hello, C!
      Goodbye, C!
    Invoking delegate d:
      Goodbye, D!
    */
