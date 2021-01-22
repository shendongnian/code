    public IEnumerable<string> SplitIntoWords( string input,
                                               IEnumerable<string> stopwords )
    {
        // use case-insensitive comparison when matching stopwords
        var comparer = StringComparer.InvariantCultureIgnoreCase;
        var stopwordsSet = new HashSet<string>( stopwords, comparer );
        var splitOn = new char[] { ' ', '\t', '\r' ,'\n' };
        // if your splitting is more complicated, you could use RegEx instead...
        // if this becomes a bottleneck, you could use loop over the string using
        // string.IndexOf() - but you would still need to allocate an extra string
        // to perform comparison, so it's unclear if that would be better or not
        var words = input.Split( splitOn, StringSplitOptions.RemoveEmptyEntries );
        // return all words longer than 2 letters that are not stopwords...
        return words.Where( w => !stopwordsSet.Contains( w ) && w.Length > 2 );
    }
