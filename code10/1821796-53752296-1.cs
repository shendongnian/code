    using System;
    using System.Linq;
    
    public class Program
    {
      // Main method begins execution of C# application
      public static void Main(string[] args)
      {
        int[] array = new int[5];
    
        for (int i = 0; i < array.Length; i++)
        {
          Console.WriteLine("Enter a number:");
          // Get user input and convert to integer:
          int input = Convert.ToInt32(Console.ReadLine());
    
          // Check if given input is already in the array: 
          if (! array.Any(number => number == input))
          {
              array[i] = input;
              Console.WriteLine("new\n");
          }
          else 
          {
              Console.WriteLine("exists\n");
          }
        }
    
        // Print the contents of array separated by ','
        Console.WriteLine(string.Join(", ", array));
        Console.ReadKey();
      }
    }
