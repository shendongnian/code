IArticleDataAccess&lt;AnalysisArticle&gt; dataAccess = new AnalysisArticleDataAccess();
//But instead have a DataAccess property in NewsArticle.  Once defined as:
IArticleDataAccess DataAccess { get; set; }
//If I change to:
IArticleDataAccess&lt;NewsArticle&gt; DataAccess { get; set; }
// It can't be implicitly set to type IArticleDataAccess&lt;AnalysisArticle&gt;.
