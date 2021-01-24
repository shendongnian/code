      using System.Collections.Generic;
      using System.Collections.Linq;
      ...
      static void Main(string[] args) {
        Console.WriteLine("Enter numbers separated by spaces, e.g. 1 2 3 15");
        double avg = Console
          .ReadLine()
          .Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries)
          .Select(item => double.Parse(item))  
          .Average();
 
        Console.Write($"The average is: {avg}"); 
      } 
