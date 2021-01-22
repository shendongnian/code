    string text = @"The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog.";
    string[] searchKeywords = { "quick", "fox", "lazy" };
    
    // build pattern based on keywords - you probably had a routine in place for this
    var patternQuery = searchKeywords
                            .Select((s, i) => 
                                String.Format("(?<c{0}>{1})", i, s) +
                                (i < searchKeywords.Length - 1 ? "|" : ""))
                            .Distinct();
    string pattern = String.Join("", patternQuery.ToArray());
    Console.WriteLine("Dynamic pattern: {0}\n", pattern);
    
    // use RegexOptions.IgnoreCase for case-insensitve search
    Regex rx = new Regex(pattern);
    
    // Notes:
    // - Skip(1): used to ignore first groupname of 0 (entire match)
    // - The idea is to use the groupname and its corresponding match. The Where
    //   clause matches the pair up correctly based on the current match value
    //   and returns the appropriate groupname
    string result = rx.Replace(text, m => String.Format(@"<span class=""{0}"">{1}</span>", 
                        rx.GetGroupNames()
                        .Skip(1)
                        .Where(g => m.Value == m.Groups[rx.GroupNumberFromName(g)].Value)
                        .Single(),
                        m.Value));
    
    Console.WriteLine("Original Text: {0}\n", text);
    Console.WriteLine("Result: {0}", result);
