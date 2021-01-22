    using System;
    
    namespace Playground
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tuple = GetTuple();
                Console.WriteLine(tuple.Item1);
                Console.WriteLine(tuple.Item2);
                Console.WriteLine(tuple.Item3);
                Console.WriteLine(tuple);
    
                Console.WriteLine("---");
    
                var dyn = GetDynamic();
                Console.WriteLine(dyn.First);
                Console.WriteLine(dyn.Last);
                Console.WriteLine(dyn.Age);
                Console.WriteLine(dyn);
    
                Console.WriteLine("---");
    
                var arr = GetArray();
                Console.WriteLine(arr[0]);
                Console.WriteLine(arr[1]);
                Console.WriteLine(arr[2]);
                Console.WriteLine(arr);
    
                Console.Read();
    
                (string, string, int) GetTuple()
                {
                    return ("John", "Connor", 1);
                }
    
                dynamic GetDynamic()
                {
                    return new { First = "John", Last = "Connor", Age = 1 };
                }
    
                dynamic[] GetArray()
                {
                    return new dynamic[] { "John", "Connor", 1 };
                }
            }
        }
    }
