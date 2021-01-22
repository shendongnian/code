    using System;
    namespace ConsoleApplication1
        {
        class Program
        {
            enum TestEnum { E1, E2, E3 }
            static void Main(string[] args)
            {
                {
                    var start = DateTime.UtcNow;
                    for (var i = 0; i < 1000000000; i++)
                        Test1(TestEnum.E2);
                    Console.WriteLine(DateTime.UtcNow - start);
                }
                {
                    var start = DateTime.UtcNow;
                    for (var i = 0; i < 1000000000; i++)
                        Test2(TestEnum.E2);
                    Console.WriteLine(DateTime.UtcNow - start);
                }
                Console.ReadLine();
            }
            static Type Test1<T>(T value) => typeof(T);
            static Type Test2(object value) => value.GetType();
        }
    }
