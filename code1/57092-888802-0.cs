    Console.Write("\r{0}   ", value); //option 1: carriage return
    Console.Write("\b\b\b\b\b{0}", value); //option 2: backspace
    {                                           //option 3 in two parts:
      Console.SetCursorPosition(0, Console.CursorTop); //move cursor
      Console.Write(value);                            //rewrite
    }
