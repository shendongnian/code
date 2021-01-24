    public static string[] GetParts(string input)
    {
        string[] parts= input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        return parts.TakeLast(2).Select(item=>item.Replace("*", string.Empty)).ToArray();
    }
