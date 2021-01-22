    public static string ReadLineMasked(char mask = '*')
    {
        var sb = new StringBuilder();
        ConsoleKeyInfo keyInfo;
        while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
        {
            if (!char.IsControl(keyInfo.KeyChar))
            {
                sb.Append(keyInfo.KeyChar);
                Console.Write(mask);
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
    
                if (Console.CursorLeft == 0)
                {
                    Console.SetCursorPosition(Console.BufferWidth - 2, Console.CursorTop - 1);
                    Console.Write(mask + " ");
                    Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                }
                else Console.Write("\b \b");
            }
        }
    
        return sb.ToString();
    }
