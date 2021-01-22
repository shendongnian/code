        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your name ");
            string input;
            if (TryReadLine(out input, 10000, true))
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("[DEFAULT]");
            }
            Console.ReadKey(true);
        }
        const string timerString = "[{0} seconds until default value is used]";
        public static bool TryReadLine(out string s, double timeout, bool showTimer)
        {
            DateTime timeoutDateTime = DateTime.Now.AddMilliseconds(10000);
            DateTime nextTimer = DateTime.Now;
            while (DateTime.Now < timeoutDateTime)
            {
                if (Console.KeyAvailable)
                {
                    ClearTimer(timeoutDateTime);
                    s = Console.ReadLine();
                    return true;
                }
                if (showTimer && DateTime.Now > nextTimer)
                {
                    WriteTimer(string.Format(timerString, (timeoutDateTime - DateTime.Now).Seconds));
                    nextTimer = DateTime.Now.AddSeconds(1);
                }
            }
            ClearTimer(timeoutDateTime);
            s = null;
            return false;
        }
        private static void ClearTimer(DateTime timeoutDateTime)
        {
            WriteTimer(new string(' ', string.Format(timerString, (timeoutDateTime - DateTime.Now).Seconds).Length));
        }
        private static void WriteTimer(string s)
        {
            int cursorLeft = Console.CursorLeft;
            Console.CursorLeft = 0;
            Console.CursorTop += 1;
            Console.Write(s);
            Console.CursorLeft = cursorLeft;
            Console.CursorTop -= 1;
        }
    }
