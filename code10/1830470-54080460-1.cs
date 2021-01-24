    static string Repeat(string input, int count)
    {
        var result = new StringBuilder();
        for (var i = 0; i < count; i++) result.Append(input);
        return result.ToString();
    }
    string mystring = 
        $"one line{Repeat(Environment.NewLine, 3)}another line{Environment.NewLine}end";
