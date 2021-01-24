       static void Main() {
         do {
           MyRoutine();
           Console.WriteLine("Would you like to repeat? Y/N");
         }
         while (char.ToUpper(Console.ReadKey().KeyChar) == 'y');
         Console.WriteLine("Press any key to exit.");
         Console.ReadKey();
       }  
