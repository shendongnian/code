    using System;
    using System.Collections.Generic;
    namespace Disposable_Variables_Reference
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<string> DCNames = null;
                string DCName = string.Empty;
                int DCValue;
                using (var disposableClass = new DisposableClass())
                {
                    DCNames = disposableClass.Names;
                    DCName = disposableClass.Name;
                    DCValue = disposableClass.Value;
                    foreach (var name in DCNames) Console.WriteLine(name);
                    Console.WriteLine(DCName);
                    Console.WriteLine(DCValue);
                }
                foreach (var name in DCNames) Console.WriteLine(name);
                Console.WriteLine(DCName);
                Console.WriteLine(DCValue);
                Console.Read();
            }
    
            public class DisposableClass : IDisposable
            {
                public List<string> Names { get; set; } = new List<string>() { "Michael", "Mark", "Luke", "John" };
                public string Name { get; set; } = "Gabriel";
                public int Value { get; set; } = 20;
                public void Dispose()
                {
                    Names.Clear();
                    Name = string.Empty;
                    Value = 0;
                }
            }
        }
    } 
   
