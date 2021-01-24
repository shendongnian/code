    namespace default {
             class test {
                   static void Main() {
                     Console.Clear();
                     string IsDemoMode;
                     Console.WriteLine("Activate Demo Mode? (Y/N)");
                     IsDemoMode = Console.ReadLine();
        
                     if (IsDemoMode.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                     {
                       // Demo code...
                     } else 
                     {
                       // Non-Demo Code...
                     };
                   }
              }
     }
