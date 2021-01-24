    private IEnumerable<Inline> Parse(string text)
    {
        Regex commandFinder = new Regex(@"\[(?<text>.+)\:(?<command>.+)]");
        var matches = commandFinder.Matches(text);
        int previousMatchEnd = 0;
        foreach (Match match in matches)
        {
            string textBeforeMatch = text.Substring(previousMatchEnd, match.Index - previousMatchEnd);
            yield return new Run(textBeforeMatch);
            previousMatchEnd = match.Index + match.Length;
            string commandText = match.Groups["text"].Value;
            string command = match.Groups["command"].Value;
            Hyperlink link = new Hyperlink(new Run(commandText));
            link.Click += (s, a) => { HandleCommand(command); };
            yield return link;
        }
        if (previousMatchEnd < text.Length)
            yield return new Run(text.Substring(previousMatchEnd));
    }
