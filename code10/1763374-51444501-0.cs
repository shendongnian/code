      private static bool ReadDouble(out double value) {
        value = 0.0;
        while (true) {
          Console.WriteLine("Enter number or X to exit:");
          string input = Console.ReadLine().Trim();
          if (input == "X" || input == "x") 
            return false;
          else if (double.TryParse(input, out value)) 
            return true;
          Console.Write("Syntax error, please, try again.");
        }
      }
