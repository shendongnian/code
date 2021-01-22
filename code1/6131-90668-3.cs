    public IEnumerable<SearchResult> SafeFindAll(DirectorySearcher searcher)
    {
        using(SearchResultCollection results = searcher.FindAll())
        {
            foreach (SearchResult result in searchResults)
            {
                yield return result;		
            } // SearchResultCollection will be disposed here
        }
    }
