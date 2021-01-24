       using System.Globalization;
       ...
       private static int ReadNonNegative(string title) {
         int result = 0;
         while (true) do {
           Console.Write($"Insert the {title} number: ");
           if (!int.TryParse(Console.ReadLine(), out result)) {
             Console.WriteLine();
             Console.WriteLine("Syntax error. Not a valid integer value. Please, try again.");
           }
           else if (result < 0) {
             Console.WriteLine();
             Console.WriteLine($"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title)} number must not be negative.");  
           } 
           else 
             return result;
         }  
       }     
