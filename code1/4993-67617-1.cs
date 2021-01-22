        // here's something that takes ages to calculate
        Func<string> MyExpensiveMethod = () => 
        { 
            System.Threading.Thread.Sleep(5000); 
            return "that took ages!"; 
        };
        // and heres a function call that only calculates it the once.
        Func<string> CachedMethod = Remember(() => MyExpensiveMethod());
        // only the first line takes five seconds; 
        // the second and third calls are instant.
        Console.WriteLine(CachedMethod());
        Console.WriteLine(CachedMethod());
        Console.WriteLine(CachedMethod());
