    class TimeStampedSearchResult
    {
        public string SearchResult { get; set; }
        public DateTime TimeStamp { get; private set; }
        public TimeStampedSearchResult(string searchResult)
        {
            SearchResult = searchResult;
            TimeStamp = DateTime.Now;
        }
        public void UpdateTimeStamp()
        {
            TimeStamp = DateTime.Now;
        }
    }
