    public class Article {
      public long ArticleId { get; set; }
      public string ArticleTitle { get; set; }
      public int NumberOfComment { get; set; }
      public int NumberOfView { get; set; }
      public virtual ICollection<ArticleReview> Reviews { get; set; }
      public Article() {
      }
      public Article(long articleId, string articleTitle, int numberOfComment, int numberOfView, ICollection<ArticleReview> reviews) {
        ArticleId = articleId;
        ArticleTitle = articleTitle;
        NumberOfComment = numberOfComment;
        NumberOfView = numberOfView;
        Reviews = reviews;
      }
      public decimal GetAverage() {
        if (Reviews.Count <= 0)
          return 0;
        decimal divisor = Reviews.Count;
        int totPoints = 0;
        foreach (ArticleReview review in Reviews) {
          totPoints += review.ReviewPoint;
        }
        return totPoints / divisor;
      }
    }
