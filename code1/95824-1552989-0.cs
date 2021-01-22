    static readonly Regex hungarian =
            new Regex(@"(string\s+_)([a-z])", RegexOptions.Compiled);
    ...
    string text = ...
    string newText = hungarian.Replace(text, match =>
        match.Groups[1].Value + "s" +
        match.Groups[2].Value.ToUpper());
