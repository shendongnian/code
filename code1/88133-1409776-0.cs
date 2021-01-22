    using System;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                var a = new { Id = 1, Name = "Bob" };
                TestMethod(a);
    
                Console.Out.WriteLine("Press enter to exit...");
                Console.In.ReadLine();
            }
    
            private static void TestMethod(Object x)
            {
                // This is a dummy value, just to get 'a' to be of the right type
                var a = new { Id = 0, Name = "" };
                a = Cast(a, x);
                Console.Out.WriteLine(a.Id + ": " + a.Name);
            }
    
            private static T Cast<T>(T typeHolder, Object x)
            {
                // typeHolder above is just for compiler magic
                // to infer the type to cast x to
                return (T)x;
            }
        }
    }
