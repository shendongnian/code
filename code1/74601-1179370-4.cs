    public IEnumerable<string> FindOccurences( IEnumerable<string> searchStrings,
                                               IEnumerable<string> positiveKeywords,
                                               IEnumerable<string> negativeKeywords )
        {
            var foundKeywordsDict = new Dictionary<string, int>();
            foreach( var searchIn in searchStrings )
            {
                // tokenize the search string...
                var tokenizedDictionary = searchIn.Split( ' ' ).ToDictionary( x => x );
                // skip if any negative keywords exist...
                if( negativeKeywords.Any( tokenizedDictionary.ContainsKey ) )
                    continue;
                // merge found positive keywords into dictionary...
                // an example of where Enumerable.ForEach() would be nice...
                var found = positiveKeywords.Where(tokenizedDictionary.ContainsKey)
                foreach (var keyword in found)
                    foundKeywordsDict[keyword] = 1;
            }
            return foundKeywordsDict.Keys;
        }
