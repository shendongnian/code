     private static int ReadInteger(string title) {
       // Keep on asking until correct input is provided
       while (true) {
         if (!string.IsNullOrWhiteSpace(title))
           Console.WriteLine(title);
         if (int.TryParse(Console.ReadLine(), out int result))
           return result;
         Console.WriteLine("Sorry, not a valid integer value; please, try again.");
       }
     }
