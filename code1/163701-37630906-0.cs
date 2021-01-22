    using System;
    using System.Dynamic;
    
    class Program
    {
        static void Main(string[] args)
        {
            dynamic expando = new ExpandoObject();
            ((IDictionary<String, object>)["A"] = "New val 1";
            ((IDictionary<String, object>)["B"] = "New val 2";
    
            Console.WriteLine(expando.A);
            Console.WriteLine(expando.B);
        }
    }
