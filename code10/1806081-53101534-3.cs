       static void Main() {
         do {
           MyRoutine();
           Console.WriteLine("Would you like to repeat? Y/N");
         }
         while (Console.ReadKey().KeyChar == 'Y');
         Console.WriteLine("Press any key to exit.");
         Console.ReadKey();
       }  
