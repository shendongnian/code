    public class Category
    {
        public long CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
    public class Article
    {
        public long ArticleId { get; set; }
        public long CategoryId { get; set; }
        public string ArticleTitle { get; set; }
        public int NumberOfComment { get; set; }
        public int NumberOfView { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ArticleReview> Reviews { get; set; }
    }
    public class ArticleReview
    {
        public long ArticleReviewId { get; set; }
        public long ArticleId { get; set; }
        public string ReviewerId { get; set; }
        public int ReviewPoint { get; set; }
        public virtual Article Article { get; set; }
    }
    public class ExcelExport
    {
        public string ArticleTitle { get; set; }
        public int NumberOfComment { get; set; }
        public int NumberOfReviews { get; set; }
        public List<ArticleReviewReport> Reviews { get; set; }
    }
    public class ArticleReviewReport
    {
        public string Reviewer { get; set; }
        public int ReviewPoint { get; set; }
    }
