        static void Main()
        {
            string txt = "Hello, world!";
            while (true)
            {
                WriteBlinkingText(txt, 500, true);
                WriteBlinkingText(txt, 500, false);
            }
        }
        private static void WriteBlinkingText(string text, int delay, bool visible)
        {
            if (visible)
                Console.Write(text);
            else
                for (int i = 0; i < text.Length; i++)
                    Console.Write(" ");
            Console.CursorLeft -= text.Length;
            System.Threading.Thread.Sleep(delay);
        }
