    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    class Program
    {
        static void Main()
        {
            dynamic expando = new ExpandoObject();
            var p = expando as IDictionary<String, object>;
            p["A"] = "New val 1";
            p["B"] = "New val 2";
            Console.WriteLine(expando.A);
            Console.WriteLine(expando.B);
        }
    }
