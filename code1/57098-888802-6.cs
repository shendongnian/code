    Console.Write("\r{0}   ", value);                      // Option 1: carriage return
    Console.Write("\b\b\b\b\b{0}", value);                 // Option 2: backspace
    {                                                      // Option 3 in two parts:
        Console.SetCursorPosition(0, Console.CursorTop);   // - Move cursor
        Console.Write(value);                              // - Rewrite
    }
