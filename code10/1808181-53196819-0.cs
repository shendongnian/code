     public static double GetPositiveNumber()
     {
         while (true)
         {
             Console.Write("Enter a Positive number: ");
             var response = Console.ReadLine();
             if (!double.TryParse(response, out var doubleValue))
             {
                 Console.WriteLine("You must enter a valid number");
                 continue;     //causes control to jump to the end of the loop (and back again)
             }
             if (doubleValue > 0)
             {
                 return doubleValue;     //The only exit to the loop
             }
             //if I get here, it's a valid number, but not positive
             Console.WriteLine("Sorry, the number must be positive...");
         }
     }
