            public static void DrawCharacter()
        {
            lastmapchar = data[oldy][oldx];
            Console.SetCursorPosition(oldx, oldy);
            // Change foreground color here, like so:
            switch (lastmapchar)
            {
                  case "#":
                      Console.Foregroundcolor = ConsoleColor.DarkYellow;
                      break;
                  //.... etc
            }
            Console.Write(lastmapchar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
            Console.Write("@");
            Console.SetCursorPosition(x, y);
            ClearKeyBuffer();
            Randomnumber = 100;
        }
