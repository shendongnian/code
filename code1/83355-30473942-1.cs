    using System;
    using System.Reactive.Linq;
    namespace ConsoleApplicationExample
    {
        class Program
        {
            static void Main()
            {
                Observable.Interval(TimeSpan.FromMinutes(1))
                .Subscribe(_ =>
                {                   
                    Console.WriteLine(DateTime.Now.ToString());
                });
                Console.WriteLine(DateTime.Now.ToString()); 
                Console.ReadLine();
            }
        }
    }
