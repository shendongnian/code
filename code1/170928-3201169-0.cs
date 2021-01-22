    using System;
    
    public struct Example
    {
       public int a;
       public string name;
    }
    
    class Test
    {
        static void Main()
        {
            Example t1 = new Example();
            t1.name = "First name";
            Example t2 = t1;
            t2.name = "Second name";
            
            Console.WriteLine(t1.name); // Prints "First name"
            Console.WriteLine(t2.name); // Prints "Second name"        
        }
    }
