    public class InsightsJavaScriptSnippet : IInsightsJavaScriptSnippet
    {
        private readonly JavaScriptSnippet _snippet;
        public InsightsJavaScriptSnippet(JavaScriptSnippet snippet)
        {
            _snippet = snippet;
        }
        public string FullScript => _snippet.FullScript;
    }
