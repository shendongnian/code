            StringBuilder sb = new StringBuilder();
            Console.WriteLine("Write a line ending in '#'.");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey();
                // Evaluate Input Key
                if (int.TryParse(keyInfo.Key.ToString(), out int i))
                {
                    ; // do something with an int
                }
                else
                {
                    ; // do something with char 
                }
                if (!((keyInfo.Key == ConsoleKey.D3) && (keyInfo.Modifiers == ConsoleModifiers.Shift)))
                {
                    sb.Append(keyInfo.KeyChar);
                }
            }
            while (!((keyInfo.Key == ConsoleKey.D3) && (keyInfo.Modifiers == ConsoleModifiers.Shift)));
            Console.WriteLine();
            Console.WriteLine($"You typed {sb.Length.ToString()} characters.");
            Console.WriteLine($"You typed {sb.ToString()}.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
