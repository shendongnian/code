       private static int InputInteger(string title) {
         Console.WriteLine(); 
         while (true) {
           if (!string.IsNullOrEmpty(title)) 
             Console.Write(title);
           if (int.TryParse(Console.ReadLine(), out var result)) 
             return result;
           Console.WriteLine("-- ERROR --");
           Console.WriteLine("Please, type integer number, try again!");
         }
       }  
