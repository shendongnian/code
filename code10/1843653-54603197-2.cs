    static void Main(string[] args)
    {
        //Console.Write("Enter tip: ");
        //string input = Console.ReadLine();
        //Console.Write("Enter path: ");
        //string path = Console.ReadLine();
        string input = "A52";
        string path = "tst.txt";
        CalcAndSave(input, path);
    }
    static void CalcAndSave(string str, string path)
    {
        List<char[]> ls = MakeList(str);
        char[] state = new char[ls.Count];
        using (var writer = new StreamWriter(path))
        {
            CalcAndSave(ls, 0, state, writer);
        }
    }
    static void CalcAndSave(List<char[]> ls, int level, char[] state, StreamWriter writer)
    {
        if (level >= ls.Count)
        {
            foreach (char c in state)
            {
                writer.Write(c);
            }
            writer.Write("\r\n");
            return;
        }
        foreach (char c in ls[level])
        {
            state[level] = c;
            CalcAndSave(ls, level + 1, state, writer);
        }
    }
    /// <summary>
    /// makes list of all possible characters, for every character in a character array
    /// </summary>
    /// <param name="inputChars"></param>
    static List<char[]> MakeList(string input)
    {
        var same = new List<string> { "a@&", "s5", "1!" };
        var ls = new List<char[]>();
        foreach (char c in input)
        {
            HashSet<char> chars = new HashSet<char>
            {
                char.ToLower(c),
                char.ToUpper(c)
            };
            foreach (char cs in same
                .Where(s => s.Contains(c, StringComparison.CurrentCultureIgnoreCase))
                .SelectMany(s => s))
            {
                chars.Add(char.ToLower(cs));
                chars.Add(char.ToUpper(cs));
            }
            ls.Add(chars.ToArray());
        }
        return ls;     
    }
