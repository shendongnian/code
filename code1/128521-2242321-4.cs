    static string Rewrite(string input)
    {
        var builder = new StringBuilder();
        var stack = new Stack<string>();
        string[] lines = input.Split('\n');
        foreach (var s in lines)
        {
            if (s.Contains("{") || s.Contains("="))
            {
                stack.Push(s.Replace("{", String.Empty).Trim());
            }
            if (s.Contains("="))
            {
                builder.Append(string.Join(".", stack.Reverse().ToArray()));
                builder.Append(Environment.NewLine);
            }
            if (s.Contains("}") || s.Contains("="))
            {
                stack.Pop();
            }
       }
       return builder.ToString();
    }
