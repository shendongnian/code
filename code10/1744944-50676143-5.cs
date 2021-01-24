    private static readonly string[] commandDelimiters = new[] { " ", "\r", "\n" };
    // We don't want the { to be used inside arguments that aren't in the form {...}
    // Note that at this time there is no way to "escape" the }
    private static readonly string[] argumentDelimiters = new[] { " ", "\r", "\n", "{" };
    public static IEnumerable<Tuple<string, string[]>> ParseCommands(string str)
    {
        int ix = 0;
        int line = 0;
        int ixStartLine = 0;
        var args = new List<string>();
        while (ix < str.Length)
        {
            string command = ParseWord(str, ref ix, commandDelimiters);
            if (command.Length == 0)
            {
                throw new Exception($"No command, at line {line}, col {ix - ixStartLine}");
            }
            while (true)
            {
                SkipSpaces(str, ref ix);
                if (IsEOL(str, true, ref ix))
                {
                    line++;
                    ixStartLine = ix;
                    break;
                }
                if (str[ix] == '{')
                {
                    int ix2 = str.IndexOf('}', ix + 1);
                    if (ix2 == -1)
                    {
                        throw new Exception($"Unclosed {{ at line {line}, col {ix - ixStartLine}");
                    }
                    // Skipping the {
                    ix++;
                    // Skipping the }, because we don't do ix2 - ix -1
                    string arg = str.Substring(ix, ix2 - ix);
                    // We count the new lines "inside" the { }
                    for (int i = 0; i < arg.Length; )
                    {
                        if (IsEOL(arg, true, ref i))
                        {
                            line++;
                            ixStartLine = ix + i + 1;
                        }
                        else
                        {
                            i++;
                        }
                    }
                    // Skipping the }
                    ix = ix2 + 1;
                    // If there is no space of eol after the } then error
                    if (ix < str.Length && str[ix] != ' ' && !IsEOL(str, false, ref ix))
                    {
                        throw new Exception($"Unexpected character at line {line}, col {ix - ixStartLine}");
                    }
                    args.Add(arg);
                }
                else
                {
                    string arg = ParseWord(str, ref ix, commandDelimiters);
                    // If the terminator is {, then error.
                    if (ix < str.Length && str[ix] == '{')
                    {
                        throw new Exception($"Unexpected character at line {line}, col {ix - ixStartLine}");
                    }
                    args.Add(arg);
                }
            }
            var args2 = args.ToArray();
            args.Clear();
            yield return Tuple.Create(command, args2);
        }
    }
    // Stops at any of terminators, doesn't "consume" it advancing ix
    public static string ParseWord(string str, ref int ix, string[] terminators)
    {
        int start = ix;
        int curr = ix;
        while (curr < str.Length && !terminators.Any(x => string.CompareOrdinal(str, curr, x, 0, x.Length) == 0))
        {
            curr++;
        }
        ix = curr;
        return str.Substring(start, curr - start);
    }
    public static bool SkipSpaces(string str, ref int ix)
    {
        bool atLeastOne = false;
        while (ix < str.Length && str[ix] == ' ')
        {
            atLeastOne = true;
            ix++;
        }
        return atLeastOne;
    }
    // \r\n, \r, \n, end-of-string == true
    public static bool IsEOL(string str, bool advance, ref int ix)
    {
        if (ix == str.Length)
        {
            return true;
        }
        if (str[ix] == '\r')
        {
            if (advance)
            {
                if (ix + 1 < str.Length && str[ix + 1] == '\n')
                {
                    ix += 2;
                }
                ix += 2;
            }
            return true;
        }
        if (str[ix] == '\n')
        {
            if (advance)
            {
                ix++;
            }
            return true;
        }
        return false;
    }
