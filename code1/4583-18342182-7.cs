    try {
      Console.WriteLine("Please enter your name within the next 5 seconds.");
      string name = Reader.ReadLine(5000);
      Console.WriteLine("Hello, {0}!", name);
    } catch (TimeoutException) {
      Console.WriteLine("Sorry, you waited too long.");
    }
