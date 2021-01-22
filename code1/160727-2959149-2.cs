    string s2 = string.Join(
        ".",
        s.Split('.')
            .Select(str => TrimLeadingZeros(str))
            .ToArray()
    );
    public static string TrimLeadingZeros(string text) {
        int number;
        if (int.TryParse(text, out number))
            return number.ToString();
        else
            return text.TrimStart('0');
    }
