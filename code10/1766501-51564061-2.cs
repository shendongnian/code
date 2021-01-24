    var keyInfo = new ConsoleKeyInfo();
    var userInput = new StringBuilder();
    var stopWatch = new Stopwatch();
    var started = false;
    do
    {
         keyInfo = Console.ReadKey(false);
   
         if (started == false)
         {
              stopWatch.Start();
              started = true;
         }                
         switch (keyInfo.Key)
         {
              case ConsoleKey.Backspace:
                  Console.Write(" \b");
                  userInput.Remove(userInput.Length - 1, 1);
                  break;
              // Stopping delete key outputting a space
              case ConsoleKey.Delete:
                  Console.Write("\b");
                  break;
              default:
                  userInput.Append(keyInfo.KeyChar);
                  break;
        }
    }
    while (keyInfo.Key != ConsoleKey.Enter);
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    var finalString = userInput.ToString();
    Console.WriteLine();
    Console.WriteLine($"String entered: {finalString}.");
    Console.WriteLine($"It took {ts.Seconds} seconds.");
    Console.ReadLine();
