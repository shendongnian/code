    public void StartSearch(string searchtext)
    {
        searcher.SearchAsync(searchtext, SearchCompleted);
    }
    
    public void SearchCompleted(IList<SearchResult> results)
    {
        // Called by the asycn searcher component, possibly on another thread
        // Consider marshalling to the UI thread here if you plan to update the UI
    
        foreach (var result in Results)
        {
            AddToList(result);
        }
    }
