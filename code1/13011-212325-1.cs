        static void Main(string[] args)
        {
            string input;
            Console.Write("Please enter your name (");
            int timerPromptStart = Console.CursorLeft;
            Console.Write("    seconds left): ");
            if (TryReadLine(out input, 10000, delegate(TimeSpan timeSpan)
                                              {
                                                  int inputPos = Console.CursorLeft;
                                                  Console.CursorLeft = timerPromptStart;
                                                  Console.Write(timeSpan.Seconds.ToString("000"));
                                                  Console.CursorLeft = inputPos;
                                              },
                                              1000))
            {
                Console.WriteLine(input);
            }
            else
            {
                Console.WriteLine("DEFAULT");
            }
            while (true) { }
        }
        /// <summary>
        /// Tries to read a line of input from the Console.
        /// </summary>
        /// <param name="s">The string to put the input into.</param>
        /// <param name="timeout">The time in milliseconds before the attempt fails.</param>
        /// <returns>Whether the user inputted a line before the timeout.</returns>
        public static bool TryReadLine(out string s, double timeout)
        {
            return TryReadLine(out s, timeout, null, 0);
        }
        /// <summary>
        /// Tries to read a line of input from the Console.
        /// </summary>
        /// <param name="s">The string to put the input into.</param>
        /// <param name="timeout">The time in milliseconds before the attempt fails.</param>
        /// <param name="timerCallback">A function to call every callbackInterval.</param>
        /// <param name="callbackInterval">The length of time between calls to timerCallback.</param>
        /// <returns>Whether the user inputted a line before the timeout.</returns>
        public static bool TryReadLine(out string s, double timeout, Action<TimeSpan> timerCallback, double callbackInterval)
        {
            const int tabLength = 6;
            StringBuilder inputBuilder = new StringBuilder();
            int readStart = Console.CursorLeft;
            int lastLength = 0;
            bool isInserting = true;
            DateTime endTime = DateTime.Now.AddMilliseconds(timeout);
            DateTime nextCallback = DateTime.Now;
            while (DateTime.Now < endTime)
            {
                if (timerCallback != null && DateTime.Now > nextCallback)
                {
                    nextCallback = DateTime.Now.AddMilliseconds(callbackInterval);
                    timerCallback((endTime - DateTime.Now));
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            Console.WriteLine();
                            s = inputBuilder.ToString();
                            return true;
                        case ConsoleKey.Backspace:
                            if (Console.CursorLeft > readStart)
                            {
                                Console.CursorLeft -= 1;
                                inputBuilder.Remove(Console.CursorLeft - readStart, 1);
                            }
                            break;
                        case ConsoleKey.Delete:
                            if (Console.CursorLeft < readStart + inputBuilder.Length)
                            {
                                inputBuilder.Remove(Console.CursorLeft - readStart, 1);
                            }
                            break;
                        case ConsoleKey.Tab:
                            // Tabs are very difficult to handle properly, so we'll simply replace it with spaces.
                            AddOrInsert(inputBuilder, new String(' ', tabLength), isInserting, readStart);
                            Console.CursorLeft += tabLength;
                            break;
                        case ConsoleKey.Escape:
                            Console.CursorLeft = readStart;
                            inputBuilder = new StringBuilder();
                            break;
                        case ConsoleKey.Insert:
                            isInserting = !isInserting;
                            // This may be dependant on a variable somewhere.
                            if (isInserting)
                            {
                                Console.CursorSize = 25;
                            }
                            else
                            {
                                Console.CursorSize = 50;
                            }
                            break;
                        case ConsoleKey.Home:
                            Console.CursorLeft = readStart;
                            break;
                        case ConsoleKey.End:
                            Console.CursorLeft = readStart + inputBuilder.Length;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (Console.CursorLeft > readStart)
                            {
                                Console.CursorLeft -= 1;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (Console.CursorLeft < readStart + inputBuilder.Length)
                            {
                                Console.CursorLeft += 1;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            // N.B. We can't handle Up like we normally would as we don't know the last console input.
                            //      You might want to handle this so it works appropriately within your own application.
                            break;
                        case ConsoleKey.PageUp:
                        case ConsoleKey.PageDown:
                        case ConsoleKey.PrintScreen:
                        case ConsoleKey.LeftWindows:
                        case ConsoleKey.RightWindows:
                        case ConsoleKey.Sleep:
                        case ConsoleKey.F1:
                        case ConsoleKey.F2:
                        case ConsoleKey.F3:
                        case ConsoleKey.F4:
                        case ConsoleKey.F5:
                        case ConsoleKey.F6:
                        case ConsoleKey.F7:
                        case ConsoleKey.F8:
                        case ConsoleKey.F9:
                        case ConsoleKey.F10:
                        case ConsoleKey.F11:
                        case ConsoleKey.F12:
                        case ConsoleKey.F13:
                        case ConsoleKey.F14:
                        case ConsoleKey.F15:
                        case ConsoleKey.F16:
                        case ConsoleKey.F17:
                        case ConsoleKey.F18:
                        case ConsoleKey.F19:
                        case ConsoleKey.F20:
                        case ConsoleKey.F21:
                        case ConsoleKey.F22:
                        case ConsoleKey.F23:
                        case ConsoleKey.F24:
                        case ConsoleKey.BrowserBack:
                        case ConsoleKey.BrowserForward:
                        case ConsoleKey.BrowserStop:
                        case ConsoleKey.BrowserRefresh:
                        case ConsoleKey.BrowserSearch:
                        case ConsoleKey.BrowserFavorites:
                        case ConsoleKey.BrowserHome:
                        case ConsoleKey.VolumeMute:
                        case ConsoleKey.VolumeUp:
                        case ConsoleKey.VolumeDown:
                        case ConsoleKey.MediaNext:
                        case ConsoleKey.MediaPrevious:
                        case ConsoleKey.MediaStop:
                        case ConsoleKey.MediaPlay:
                        case ConsoleKey.LaunchMail:
                        case ConsoleKey.LaunchMediaSelect:
                        case ConsoleKey.LaunchApp1:
                        case ConsoleKey.LaunchApp2:
                        case ConsoleKey.Play:
                        case ConsoleKey.Zoom:
                        case ConsoleKey.NoName:
                        case ConsoleKey.Pa1:
                            // These keys shouldn't do anything.
                            break;
                        case ConsoleKey.Clear:
                        case ConsoleKey.Pause:
                        case ConsoleKey.Select:
                        case ConsoleKey.Print:
                        case ConsoleKey.Execute:
                        case ConsoleKey.Process:
                        case ConsoleKey.Help:
                        case ConsoleKey.Applications:
                        case ConsoleKey.Packet:
                        case ConsoleKey.Attention:
                        case ConsoleKey.CrSel:
                        case ConsoleKey.ExSel:
                        case ConsoleKey.EraseEndOfFile:
                        case ConsoleKey.OemClear:
                            // I'm not sure what these do.
                            break;
                        default:
                            Console.Write(key.KeyChar);
                            AddOrInsert(inputBuilder, key.KeyChar.ToString(), isInserting, readStart);
                            break;
                    }
                    // Write what has current been typed in back out to the Console.
                    // We write out everything after the cursor to handle cases where the current input string is shorter than before
                    // (i.e. the user deleted stuff).
                    // There is probably a more efficient way to do this.
                    int oldCursorPos = Console.CursorLeft;
                    Console.CursorLeft = readStart;
                    Console.Write(inputBuilder.ToString());
                    if (lastLength > inputBuilder.Length)
                    {
                        Console.Write(new String(' ', lastLength - inputBuilder.Length));
                    }
                    lastLength = inputBuilder.Length;
                    Console.CursorLeft = oldCursorPos;
                }
            }
            // The timeout period was reached.
            Console.WriteLine();
            s = null;
            return false;
        }
        // This is a rather ugly helper method to add text to the inputBuilder, either inserting or appending as appropriate.
        private static void AddOrInsert(StringBuilder inputBuilder, string s, bool insert, int readStart)
        {
            if (Console.CursorLeft < readStart + inputBuilder.Length + (insert ? -1 : 1))
            {
                if (!insert)
                {
                    inputBuilder.Remove(Console.CursorLeft - 1 - readStart, 1);
                }
                inputBuilder.Insert(Console.CursorLeft - 1 - readStart, s);
            }
            else
            {
                inputBuilder.Append(s);
            }
        }
    }
