    class Program
    {
        static void Hello(string s)
        {
            Console.WriteLine("  Hello, {0}!", s);
        }
    
        static void Goodbye(string s)
        {
            Console.WriteLine("  Goodbye, {0}!", s);
        }
    
        delegate void Del(string s);
    
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
    
            Console.WriteLine("Invoking delegate a:");
            a("A");
            Console.WriteLine("Invoking delegate b:");
            b("B");
            Console.WriteLine("Invoking delegate c:");
            c("C");
            Console.WriteLine("Invoking delegate d:");
            d("D");
    
    
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
    
            Console.ReadLine();
        }
    }
