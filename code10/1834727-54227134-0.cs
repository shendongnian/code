    static int GetAnswer( string prompt, int min , int max )
    {
      if (min > max) throw new ArgumentException("min must be less than or equal to max");
      int    value   ;
      bool   valid = false ;
      do
      {
        Console.WriteLine(prompt);
        string answer  = Console.ReadLine().Trim() ;
        valid =  int.TryParse(answer, out value)
              && value >= min
              && value <= max
              ;
        if (!valid)
        {
          Console.WriteLine($"Sorry, please only type in whole numbers in the range {min}-{max}.");
        }
      } while (!valid );
      return value;
    }
