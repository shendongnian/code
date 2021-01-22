    using System;
    using System.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            var xs = Observable.Range(1, 10)
                               .Select(x => 10 / (5 - x));
            
            xs.Subscribe(x => Console.WriteLine("Received {0}", x),
                         ex => Console.WriteLine("Bang! {0}", ex),
                         () => Console.WriteLine("Done"));
            
            Console.WriteLine("App ending normally");
        }
    }
