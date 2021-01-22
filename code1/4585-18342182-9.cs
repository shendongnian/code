    Console.WriteLine("Please enter your name within the next 5 seconds.");
    string name;
    bool success = Reader.TryReadLine(out name, 5000);
    if (!success)
      Console.WriteLine("Sorry, you waited too long.");
    else
      Console.WriteLine("Hello, {0}!", name);
