    static List<ArraySegment<char>> SubstringsOf(char[] value)
    {
        var substrings = new List<ArraySegment<char>>();
        for (int length = 1; length < value.Length; length++)
            for (int start = 0; start <= value.Length - length; start++)
                substrings.Add(new ArraySegment<char>(value, start, length));
        return substrings;
    }
