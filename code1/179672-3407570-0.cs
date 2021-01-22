    using System;
    
    class Test
    {
        static void Main()
        {
            Console.Write("Hello");
            WriteOnBottomLine("Bottom!");
            Console.WriteLine(" there");
        }
        
        static void WriteOnBottomLine(string text)
        {
            int x = Console.CursorLeft;
            int y = Console.CursorTop;
            Console.CursorTop = Console.WindowHeight - 1;
            Console.Write(text);
            // Restore previous position
            Console.SetCursorPosition(x, y);
        }
    }
