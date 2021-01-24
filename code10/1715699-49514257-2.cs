    private IEnumerable<Inline> Parse(string text)
    {
        // Define the format of "special" message segments
        Regex commandFinder = new Regex(@"\[(?<text>.+)\:(?<command>.+)]");
        // Find all matches in the message text
        var matches = commandFinder.Matches(text);
        // remember where to split the string so we don't lose other 
        // parts of the message
        int previousMatchEnd = 0;
        // loop over all matches
        foreach (Match match in matches)
        {
            // extract the text fore it
            string textBeforeMatch = text.Substring(previousMatchEnd, match.Index - previousMatchEnd);
            yield return new Run(textBeforeMatch);
            previousMatchEnd = match.Index + match.Length;
            // extract information and create a clickable link
            string commandText = match.Groups["text"].Value;
            string command = match.Groups["command"].Value;
            // it would be better to use the "Command" property here,
            // but for a quick demo this will do
            Hyperlink link = new Hyperlink(new Run(commandText));
            link.Click += (s, a) => { HandleCommand(command); };
            yield return link;
        }
        // return the rest of the message (or all of it if there was no match)
        if (previousMatchEnd < text.Length)
            yield return new Run(text.Substring(previousMatchEnd));
    }
