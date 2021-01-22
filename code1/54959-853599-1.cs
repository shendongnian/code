    public static IEnumerable<string> GetItemsFromDelimitedString(string s)
    {
        bool escaped = false;
        StringBuilder sb = new StringBuilder();
        foreach (char c in s)
        {
            if ((c == '\\') && !escaped)
            {
                escaped = true;
            }
            else if ((c == ',') && !escaped)
            {
                yield return sb.ToString();
                sb.Length = 0;
            }
            else
            {
                sb.Append(c);
                escaped = false;
            }
        }
        yield return sb.ToString();
    }
