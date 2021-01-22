    public static string ReadPassword()
    {
        string password = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return null;
                case ConsoleKey.Enter:
                    return password;
                case ConsoleKey.Backspace:
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                    break;
                default:
                    password += key.KeyChar;
                    Console.Write("*");
                    break;
            }
        }
    }
