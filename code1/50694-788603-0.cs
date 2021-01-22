    public static string CommaQuibbling(IEnumerable<string> items)    
    {
        var aggregate = items.Aggregate<string, StringBuilder>(
            new StringBuilder(), 
            (b,s) => b.AppendFormat(", {0}", s));
        var trimmed = Regex.Replace(aggregate.ToString(), "^, ", string.Empty);
        return string.Format(
                   "{{{0}}}", 
                   Regex.Replace(trimmed, 
                       ", (?<last>[^,]*)$", @" and ${last}"));
    }
