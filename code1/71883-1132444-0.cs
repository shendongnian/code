    IArticleDataAccess int SaveArticle(NewsArticle article)
    {
        AnalysisArticle analysisArticle = article as AnalysisArticle;
        if (analysisArticle != null)
                SaveArticle(analysisArticle);
        //else handle error or another routine
    }
    
    public int SaveArticle(AnalysisArticle thisArticle)
    {
         //freely user analysis article members
    }
