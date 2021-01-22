        private const string _CapsLockMessage = " CAPS LOCK";
        /// <summary>
        /// Like System.Console.ReadLine(), only with a mask.
        /// </summary>
        /// <param name="mask">a <c>char</c> representing your choice of console mask</param>
        /// <returns>the string the user typed in</returns>
        public static string ReadLineMasked(char mask = '*')
        {
            // Taken from http://stackoverflow.com/a/19770778/486660
            var consoleLine = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            bool isDone;
            bool isAlreadyLocked;
            bool isCapsLockOn;
            int cursorLeft;
            int cursorTop;
            ConsoleColor originalForegroundColor;
            isDone = false;
            isAlreadyLocked = Console.CapsLock;
            while (isDone == false)
            {
                isCapsLockOn = Console.CapsLock;
                if (isCapsLockOn != isAlreadyLocked)
                {
                    if (isCapsLockOn)
                    {
                        cursorLeft = Console.CursorLeft;
                        cursorTop = Console.CursorTop;
                        originalForegroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", _CapsLockMessage);
                        Console.SetCursorPosition(cursorLeft, cursorTop);
                        Console.ForegroundColor = originalForegroundColor;
                    }
                    else
                    {
                        cursorLeft = Console.CursorLeft;
                        cursorTop = Console.CursorTop;
                        Console.Write("{0}", string.Empty.PadRight(_CapsLockMessage.Length));
                        Console.SetCursorPosition(cursorLeft, cursorTop);
                    }
                    isAlreadyLocked = isCapsLockOn;
                }
                if (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(intercept: true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        isDone = true;
                        continue;
                    }
                    if (!char.IsControl(keyInfo.KeyChar))
                    {
                        consoleLine.Append(keyInfo.KeyChar);
                        Console.Write(mask);
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace && consoleLine.Length > 0)
                    {
                        consoleLine.Remove(consoleLine.Length - 1, 1);
                        if (Console.CursorLeft == 0)
                        {
                            Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                            Console.Write(' ');
                            Console.SetCursorPosition(Console.BufferWidth - 1, Console.CursorTop - 1);
                        }
                        else
                        {
                            Console.Write("\b \b");
                        }
                    }
                    if (isCapsLockOn)
                    {
                        cursorLeft = Console.CursorLeft;
                        cursorTop = Console.CursorTop;
                        originalForegroundColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("{0}", _CapsLockMessage);
                        Console.CursorLeft = cursorLeft;
                        Console.CursorTop = cursorTop;
                        Console.ForegroundColor = originalForegroundColor;
                    }
                }
            }
            Console.WriteLine();
            return consoleLine.ToString();
        }
