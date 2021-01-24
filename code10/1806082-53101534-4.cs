       private static void MyRoutine() {
         Console.Write("Enter your selection (1, 2, or 3): "); 
         String input = Console.ReadLine();
         int n = 0;
         // User Input validation: we want integer value (int.TryParse) in the desired rang
         if (!int.TryParse(input, out n)) {
           Console.WriteLine("Sorry, invalid selection. Integer value expected");  
           return;
         }
         else if (n < 1 || n > 3) {
           Console.WriteLine("Sorry, invalid selection. Range of 1..3 expected.");
           return;         
         } 
 
         // n is valid
         switch (n) {
           case 1:
             Console.WriteLine("Current value is {0}", 1);
             break;
           case 2:
             Console.WriteLine("Current value is {0}", 2);
             break;
           case 3:
             Console.WriteLine("Current value is {0}", 3);
             break;
         }
       }
