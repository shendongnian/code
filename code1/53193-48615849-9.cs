     ...
     var n = new Numeric(); // can be an static prop
   
     Console.WriteLine(IsZero(n, 5)); // false
     Console.WriteLine(IsZero(n, 0f)); // true
     Console.WriteLine(IsZero(n, "0")); // compiler error
