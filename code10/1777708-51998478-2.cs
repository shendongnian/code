      string equation = "25x+20=120";
      if (string.IsNullOrEmpty(equation))
        throw new ArgumentException("No equation given!");
      //match all numbers
      var numbers = Regex.Matches(equation, @"\d+");
      //match all symbols
      var letters = Regex.Matches(equation, @"[a-zA-Z]");
      //take out all digits and letters, so only symbosl are left
      var symbols = Regex.Replace(equation, @"[0-9a-zA-Z]", "");
      //alternative:
      //var symbols = Regex.Matches(equation, @"[^0-9a-zA-Z]");
      foreach(Match number in numbers)
      {
        Console.WriteLine("{0} is a Number ", number.ToString());
      }
      foreach (Match letter in letters)
      {
        Console.WriteLine("{0} is a Letter ", letter.ToString());
      }
      //alternative
      //foreach (Match symbol in symbols)
      foreach (char symbol in symbols)
      {
        Console.WriteLine("{0} is a Symbol ", symbol.ToString());
      }
