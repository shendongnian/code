    static void AddRange(this IList<char> list, char start, char end) {
        for (char c = start; c <= end; c++) {
            list.Add(c);
        }
    }
    static void Main() {
        List<char> chars = new List<char>();
        chars.AddRange('\u0000', '\u0008');
        chars.AddRange('\u000B', '\u000C');
    }
