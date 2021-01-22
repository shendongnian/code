        private static string ReadBox(int maxLen)
        {
            var sb = new StringBuilder();
            int pos = 0;
            bool done = false;      
            int start = Console.CursorLeft;
            while (!done)
            {
                var ki = Console.ReadKey(true);
                switch (ki.Key)
                {
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                    case ConsoleKey.Delete:
                        // todo
                        break;
                    case ConsoleKey.Backspace:
                        if (pos > 0)
                        {
                            pos -= 1;
                            sb.Remove(pos, 1);
                        }                                
                        break;
                    case ConsoleKey.LeftArrow:
                        if (pos > 0) pos -= 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (pos < sb.Length) pos += 1;
                        break;
                    default:
                        if (ki.KeyChar >= ' ')  // simple filter
                        {
                            sb.Insert(pos, ki.KeyChar);
                            pos += 1;
                        }
                        break;
                }
                Console.CursorLeft = start;
                Console.Write(sb.ToString());
                Console.CursorLeft = start + pos;                
            }
            return sb.ToString();
        }
