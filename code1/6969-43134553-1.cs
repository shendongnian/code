     public static void EnumerateAllSuitsDemoMethod()
     {
         // custom method
         var foos = GetValues<Suit>(); 
         foreach (var foo in foos)
         {
             // Do something
         }
     }
