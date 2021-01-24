    private static int? ReadInteger(string title) {
      if (string.IsNullOrWhiteSpace(title))
        Console.WriteLine("Please, input integer value or \"quit\"");
      else
        Console.WriteLine($"{title}. Print \"quit\" to exit.");
      while (true) {
        string value = Console.ReadLine().Trim();
        if (string.Equals(value, "quit", StringComparison.OrdinalIgnoreCase))
          return null;
        else if (int.TryParse(value, out int result))
          return result;
        Console.WriteLine("Sorry, the format is incorrect. Please, try again.");
      }
    }
    private static void Report(int number) {
      Console.WriteLine(number <= 0 
        ? "Wow that number is too low for me!"
        : String.Join(", ", Enumerable.Range(1, number)));
    }
