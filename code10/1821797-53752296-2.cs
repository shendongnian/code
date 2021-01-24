    using System;
    using System.Linq;
    
    public class Program
    {
      public static void Main(string[] args)
      {
        // Btw, if this is not an array of nullables,
        // we will not be able to insert a zero later, as
        // we will treat them as duplicates.
        int?[] array = new int?[5];
    
        for (int i = 0; i < array.Length; i++)
        {
          Console.WriteLine("Enter a number:");
          
          int input = 0;
          bool duplicateAttempt = false;
          do {
            // Get and convert the input.
            input = Convert.ToInt32(Console.ReadLine());
            // See if this number is already in.
            duplicateAttempt = array.Contains(input);
            // Report if we attempt to insert a duplicate.
            if (duplicateAttempt) Console.WriteLine("exists");
          } 
          while (duplicateAttempt); // Keep asking while we don't get a unique number.
    
          array[i] = input; // Store the number
          Console.WriteLine("new");
        }
    
        // Print the contents of array separated by ','
        Console.WriteLine(string.Join(", ", array));
        Console.ReadKey();
      }
    }
