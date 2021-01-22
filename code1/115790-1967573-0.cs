    ConsoleKeyInfo info;
    do {
        info = Console.ReadKey(true);
        if ((info.Modifiers & ConsoleModifiers.Alt) > 0) Console.Write("Alt+");
        if ((info.Modifiers & ConsoleModifiers.Control) > 0 ) Console.Write("Control+");
        if ((info.Modifiers & ConsoleModifiers.Shift) > 0) Console.Write("Shift+");
        Console.WriteLine(info.Key.ToString());
     } while (info.Key != ConsoleKey.Escape);
