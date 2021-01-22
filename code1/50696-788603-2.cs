    public static string CommaQuibbling(IEnumerable<string> items)    
    {
        string last = string.Empty;
        var aggregate = items.Aggregate<string, StringBuilder>(
            new StringBuilder(), 
            (b, s) => { last = s;  return b.AppendFormat(", {0}", s); });
        var trimmed = Regex.Replace(aggregate.ToString(), "^, ", string.Empty);
        return string.Format("{{{0}}}", 
            Regex.Replace(
                trimmed, 
                string.Format(", (?<last>{0})$", last), 
                @" and ${last}"));
    }
