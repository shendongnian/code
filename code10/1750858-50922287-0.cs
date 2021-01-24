    private static IEnumerable<string> GetListOfString(string input, string start, string end)
    {
       var regex = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
       var matches = regex.Matches(input);
       return (from object match in matches select match.ToString()).ToList();
    }
