    static void Main(string[] args)
    {
        bool IsRunning = true;
        int Selected = 1;
        while (IsRunning)
        {
            ConsoleKeyInfo NextKey = new ConsoleKeyInfo();
            if (Selected < 1)
                Selected = 3;
            else if (Selected > 3)
                Selected = 1;
            Console.Clear();
            if (Selected == 1)
                Console.Write("> ");
            Console.WriteLine("Option 1");
            Console.WriteLine();
            if (Selected == 2)
                Console.Write("> ");
            Console.WriteLine("Option 2");
            Console.WriteLine();
            if (Selected == 3)
                Console.Write("> ");
            Console.WriteLine("Option 3");
            Console.WriteLine();
            Console.Write("Choose an option (Q to Quit): ");
            while (!(NextKey.Key == ConsoleKey.DownArrow ||
                    NextKey.Key == ConsoleKey.UpArrow ||
                    NextKey.Key == ConsoleKey.Q ||
                    (NextKey.KeyChar >= '1' &&
                    NextKey.KeyChar <= '3')))
            {
                NextKey = Console.ReadKey();
            }
            switch (NextKey.Key)
            {
                case ConsoleKey.D1:
                    // Do something
                    break;
                case ConsoleKey.D2:
                    // Do something
                    break;
                case ConsoleKey.D3:
                    // Do something
                    break;
                case ConsoleKey.DownArrow:
                    Selected++;
                    break;
                case ConsoleKey.UpArrow:
                    Selected--;
                    break;
                case ConsoleKey.Q:
                    IsRunning = false;
                    break;
            }
        }
    }
