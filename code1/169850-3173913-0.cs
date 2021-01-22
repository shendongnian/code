    public static void ClearArea(int top, int left, int height, int width) 
    {
        ConsoleColor colorBefore = Console.BackgroundColor;
        try
        {
            Console.BackgroundColor = ConsoleColor.Black;
            string spaces = new string(' ', width);
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(spaces);
            }
        }
        finally
        {
            Console.BackgroundColor = colorBefore;
        }
    }
