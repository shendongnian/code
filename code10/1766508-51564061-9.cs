    var keyInfo = new ConsoleKeyInfo();
    var userInput = new StringBuilder();
    var stopWatch = new Stopwatch();
    var started = false;
    
    do
    {
        keyInfo = Console.ReadKey(true);
    
        if (started == false)
        {
            stopWatch.Start();
            started = true;
        }
    
        if (keyInfo.Key == ConsoleKey.Backspace)
        {
            Console.Write("\b \b");
            if(userInput.Length > 0) userInput.Remove(userInput.Length - 1, 1);
        }
        else if (keyInfo.Key == ConsoleKey.Enter)
        {
            // Do nothing
        }
        else if(Char.IsLetter(keyInfo.KeyChar) ||
                Char.IsDigit(keyInfo.KeyChar) ||
                Char.IsWhiteSpace(keyInfo.KeyChar) ||
                Char.IsPunctuation(keyInfo.KeyChar))
    
        {
            Console.Write(keyInfo.KeyChar);
            userInput.Append(keyInfo.KeyChar);
        }
    } while (keyInfo.Key != ConsoleKey.Enter);
    
    stopWatch.Stop();
    TimeSpan ts = stopWatch.Elapsed;
    
    var finalString = userInput.ToString();
    
    Console.WriteLine();
    
    Console.WriteLine($"String entered: {finalString}.");
    Console.WriteLine($"It took {ts.Seconds} seconds.");
    
    Console.ReadLine();
