    public SearchForm : Form
    {
        public void StartSearch(string searchtext)
        {
            searcher.SearchAsync(searchtext, SearchCompleted);
        }
        public void SearchCompleted(IList<SearchResult> results)
        {
            // Called by the async searcher component, possibly on another thread
            // Consider marshalling to the UI thread here if you plan to update the UI like this:
            if (InvokeRequired) 
            {
                Invoke(new Action<IList<SearchResult>>(SearchCompleted), results);
                return;
            }
            foreach (var result in Results)
            {
                AddToList(result);
            }
        }
    }
