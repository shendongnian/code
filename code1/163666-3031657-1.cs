    private static string Translate(string input, string from, string to)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char ch in input)
        {
            int i = from.IndexOf(ch);
            if (i < 0)
            {
                sb.Append(ch);
            }
            else if (i < to.Length)
            {
                sb.Append(to[i]);
            }
        }
        return sb.ToString();
    }
