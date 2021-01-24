    public SearchForever()
    {
        //the results list
        List<TimeStampedSearchResult> results = new List<TimeStampedSearchResult>();
        //a list of expired results to remove from results list
        List<TimeStampedSearchResult> expiredResults = new List<TimeStampedSearchResult>();
        while (true)
        {
            //search for a result
            var searchResult = new TimeStampedSearchResult(SearchForStuff());
            bool found = false;
            //iterate our list
            foreach (var result in results)
            {
                if (result.SearchResult == searchResult.SearchResult)
                {
                    result.UpdateTimeStamp();
                    found = true;
                }
                else
                {
                    if (result.TimeStamp < DateTime.Now.AddMinutes(-15))
                    {
                        expiredResults.Add(result);
                    }
                }
            }
            if (!found)
            {
                //add to our results list
                results.Add(searchResult);
                //write result to file
                WriteResult(searchResult.SearchResult, "myfile.txt")
            }
            //remove expired results
            foreach (var oldResult in expiredResults)
                results.Remove(oldResult);
            //make sure you clear the expired results list too.
            expiredResults.Clear();
        }
    }
