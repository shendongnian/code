    public class ArticleReview {
      public long ArticleId { get; set; }
      public Reviewer TheReviewer { get; set; }
      public int ReviewPoint { get; set; }
      public ArticleReview() {
      }
      public ArticleReview (long articleId, Reviewer reviewerId, int reviewPoint) {
        ArticleId = articleId;
        TheReviewer = reviewerId;
        ReviewPoint = reviewPoint;
      }
    }
