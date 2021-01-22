            char[] buffer = "Initial text".ToCharArray();
            Console.WriteLine(buffer);
            Console.SetCursorPosition(Console.CursorLeft + buffer.Length, Console.CursorTop - 1);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        ...
                }
            }
