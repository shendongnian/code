    static void WriteColor(string str)
    {
        var fgStack = new Stack<ConsoleColor>();
        var bgStack = new Stack<ConsoleColor>();
        var parts = str.Split(new[] { "<*" }, StringSplitOptions.None);
        foreach (var part in parts)
        {
            var tokens = part.Split(new[] { "*>" }, StringSplitOptions.None);
            if (tokens.Length == 1)
            {
                Console.Write(tokens[0]);
            }
            else
            {
                if (!String.IsNullOrEmpty(tokens[0]))
                {
                    ConsoleColor color;
                    if (tokens[0][0] == '!')
                    {
                        if (Enum.TryParse(tokens[0].Substring(1), true, out color))
                        {
                            bgStack.Push(Console.BackgroundColor);
                            Console.BackgroundColor = color;
                        }
                    }
                    else if (tokens[0][0] == '/')
                    {
                        if (tokens[0].Length > 1 && tokens[0][1] == '!')
                        {
                            if (bgStack.Count > 0)
                                Console.BackgroundColor = bgStack.Pop();
                        }
                        else
                        {
                            if (fgStack.Count > 0)
                                Console.ForegroundColor = fgStack.Pop();
                        }
                    }
                    else
                    {
                        if (Enum.TryParse(tokens[0], true, out color))
                        {
                            fgStack.Push(Console.ForegroundColor);
                            Console.ForegroundColor = color;
                        }
                    }
                }
                for (int j = 1; j < tokens.Length; j++)
                    Console.Write(tokens[j]);
            }
        }
    }
    static void WriteLineColor(string str)
    {
        WriteColor(str);
        Console.WriteLine();
    }
    
    static void WriteColor(string str, params object[] arg)
    {
        WriteColor(String.Format(str, arg));
    }
    
    static void WriteLineColor(string str, params object[] arg)
    {
        WriteColor(String.Format(str, arg));
        Console.WriteLine();
    }
