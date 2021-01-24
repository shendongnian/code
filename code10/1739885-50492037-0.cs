    class SearchRequest {
        public string Reference {get;set;}
        public string PolicyGroup {get;set;}
        // ...
    }
    public HttpResponseMessage RiskGridView(SearchRequest query)
