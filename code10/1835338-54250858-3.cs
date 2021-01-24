       private static int InputInteger(string title) {
         Console.WriteLine(); 
         // Keep on asking user
         while (true) {
           if (!string.IsNullOrEmpty(title)) 
             Console.Write(title);
           // if correct integer value provided, return it
           if (int.TryParse(Console.ReadLine(), out var result)) 
             return result;
           // in case of syntax error print the message
           Console.WriteLine("-- ERROR --");
           Console.WriteLine("Please, type integer number, try again!");
         }
       }  
