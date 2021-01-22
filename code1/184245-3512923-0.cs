    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            Guid x = Guid.NewGuid();
            Guid y = new Guid(x.ToString());
    
            Console.WriteLine(x == y);
            Console.WriteLine(x.Equals(y));
            Console.WriteLine(x.ToString() == y.ToString());
        }
    }
