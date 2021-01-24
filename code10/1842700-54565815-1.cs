    public class SearchResult
    {
        public string Rate { get; set; }
    }
    
    
    JObject rateSearch = JObject.Parse(MyJsonText);
    
    // get JSON result objects into a list
    IList<JToken> results = rateSearch ["bpi"]["USD"].Children().ToList();
    
    // serialize JSON results into .NET objects
    IList<SearchResult> searchResults = new List<SearchResult>();
    foreach (JToken result in results)
    {
        // JToken.ToObject is a helper method that uses JsonSerializer internally
        SearchResult searchResult = result.ToObject<SearchResult>();
        searchResults.Add(searchResult);
    }
