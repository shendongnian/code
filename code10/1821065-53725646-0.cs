     if (a is System.ValueType)
     {
       //never
        Console.WriteLine("List is value type");
     }
     if ('s' is System.ValueType)
     {
         //always
         Console.WriteLine("char is value type");
     }
