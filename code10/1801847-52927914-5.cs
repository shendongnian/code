       private static int[] ReadUniqueNumbers(int count) {
         int[] result = new int[count];
         int numberCount = 0;
         while (numberCount < count) {
           int number = 0;
           // When working with user input we should be ready for any string:
           // user may well input "bla-bla-bla" (not an integer at all)
           if (!int.TryParse(Console.ReadLine(), out number))  
             Console.WriteLine("Syntax error. Not a valid integer value. Try again.");
           else {
             bool found = false;
             // Do we have duplicates? 
             // Linq (for reference only)
             // found = result.Take(numberCount).Any(item => item == number);
             for (int i = 0; i < numberCount; ++i)
               if (result[i] == number) {
                 found = true; 
                 break;
               }
             if (found) // Duplicate found
               Console.WriteLine("Hold on, you already entered that number. Try again."); 
             else {
               result[numberCount] = number;
               numberCount += 1; 
             }
           }  
         }
          
         return result;       
       } 
      
