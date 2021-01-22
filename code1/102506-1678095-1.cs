    const Int32 MAX_WIDTH = 60;
    string text = "...";
    List<string> lines = new List<string>();
    StringBuilder line = new StringBuilder();
    foreach(Match word in Regex.Matches(text, @"\S+", RegexOptions.ECMAScript))
    {
        if (word.Value.Length + line.Length + 1 > MAX_WIDTH)
        {
            lines.Add(line.ToString());
            line.Length = 0;
        }
        line.Append(String.Format("{0} ", word.Value));
    }
    if (line.Length > 0)
        line.Append(word.Value);
