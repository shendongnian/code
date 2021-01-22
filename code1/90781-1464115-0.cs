    using System;
    using System.Data.Linq;
    
    class Program {
    
        static void Main(string[] args)
        {
            Binary a = new Binary(new byte[] { 1, 2, 3 });
            Binary b = new Binary(new byte[] { 1, 2, 3 });
            
            Console.WriteLine(a.Equals(b)); // Prints True
        }
    }
