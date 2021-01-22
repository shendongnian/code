     public static void SlimShady()
     {
         void Hi([CallerMemberName] string name = null)
         {
             Console.WriteLine($"Hi! My name is {name}");
         }
    
         Hi();
     }
