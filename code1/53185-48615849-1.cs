    bool IsZero<TNum, T>(TNum ops, T number) 
       where TNum : INumeric<T>
    {
       return number == ops.Zero;      
    }
     ...
     var n = new Numeric(); // can be an static prop
     int x = 5;
     float y = 0;
     string z = "0";
     Console.WriteLine(IsZero(n, x));
     Console.WriteLine(IsZero(n, y));
     Console.WriteLine(IsZero(n, z)); // compiler error
