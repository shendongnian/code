    // Backspace Should Not Work
    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
    {
       pass += key.KeyChar;
       Console.Write("*");
    }
    else
    {
       if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
       {
          pass = pass.Substring(0, (pass.Length - 1));
          Console.Write("\b \b");
       }
    }
