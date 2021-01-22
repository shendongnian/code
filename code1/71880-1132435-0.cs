    public interface IArticleDataAccess<T> where T : NewsArticle
    {
        int SaveArticle(T thisArticle);
    }
    public AnalysisDataAccess : IArticleDataAccess<AnalysisArticle> {
      public int SaveArticle(AnalysisArticle thisArticle) {
        // Specific save code that needs properties of AnalysisArticle not found in NewsArticle.
    }
    public class AnalysisArticle : NewsArticle {
      IArticleDataAccess<AnalysisArticle> dataAccess = new AnalysisArticleDataAccess();
      int Save() {
        return dataAccess.SaveArticle(this);
      }
    }
