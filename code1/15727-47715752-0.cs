    enum Match {
        Regex,
        Wildcard,
        ContainsString,
    }
    // Don't: This way, Enumerate() can be called in a way
    //         which does not make sense:
    IEnumerable<string> Enumerate(string searchPattern = null,
                                  Match match = Match.Regex,
                                  SearchOption searchOption = SearchOption.TopDirectoryOnly);
    // Better: Provide only overloads which cannot be mis-used:
    IEnumerable<string> Enumerate(SearchOption searchOption = SearchOption.TopDirectoryOnly);
    IEnumerable<string> Enumerate(string searchPattern, Match match,
                                  SearchOption searchOption = SearchOption.TopDirectoryOnly);
