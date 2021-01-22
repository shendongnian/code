    static void WhatAmI<T>() where T : new() { 
        T t = new T(); 
        Console.WriteLine("t.ToString(): {0}", t.ToString());
        Console.WriteLine("t.GetHashCode(): {0}", t.GetHashCode());
        Console.WriteLine("t.Equals(t): {0}", t.Equals(t)); 
        Console.WriteLine("t.GetType(): {0}", t.GetType()); 
    } 
