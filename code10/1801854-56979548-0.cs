      public static void Main (string[] args) {
        var numbers = new List<int>();
        while(numbers.Count() < 5)
        {
          var line = Console.ReadLine();
          int number;
          if (int.TryParse(line, out number)) {
            if (numbers.Contains(number))
              Console.WriteLine("You already entered " + line);
            else
              numbers.Add(number);
          } else
            Console.WriteLine(line + " is not a number");
        }
        Console.WriteLine(string.Join(", ", numbers.OrderBy(i => i)));
      }
