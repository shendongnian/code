     ...
     var n = new Numeric(); // can be an static prop
   
     Console.WriteLine(IsZero(n, 5));
     Console.WriteLine(IsZero(n, 0f));
     Console.WriteLine(IsZero(n, "0")); // compiler error
