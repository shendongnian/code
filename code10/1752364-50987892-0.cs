            bool show = true;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                }
                Console.ForegroundColor = show ? ConsoleColor.White : ConsoleColor.Black;
                Console.SetCursorPosition(47, 15);
                Console.WriteLine("[Press 'Enter' to start game]");
                System.Threading.Thread.Sleep(show ? 2000 : 1000);
                show = !show;
            }
