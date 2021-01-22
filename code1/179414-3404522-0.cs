    // Backspace Should Not Work
    if (key.Key != ConsoleKey.Backspace)
    {
       pass += key.KeyChar;
       Console.Write("*");
    }
    else
    {
       if (pass.Length > 0)
       {
          pass = pass.Substring(0, (pass.Length - 1));
          Console.Write("\b \b");
       }
    }
