    public AnalysisDataAccess : IArticleDataAccess {
      public int SaveArticle(NewsArticle thisArticle) {
        AnalysisArticle theArticle = thisArticle as AnalysisArticle;
        if (theArticle != null) {
        // Specific save code that needs properties of AnalysisArticle not found in 
