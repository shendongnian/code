    public class Category {
      public long CategoryId { get; set; }
      public string CategoryTitle { get; set; }
      //...
      public virtual ICollection<Article> Articles { get; set; }
      public Category() {
      }
      public Category(long categoryId, string categoryTitle, ICollection<Article> articles) {
        CategoryId = categoryId;
        CategoryTitle = categoryTitle;
        Articles = articles;
      }
      public DataTable GetDataTable() {
        List<Reviewer> allReviewers = GetNumberOfReviewers();
        DataTable dt = new DataTable();
        dt.Columns.Add("Title", typeof(string));
        dt.Columns.Add("#ofView", typeof(long));
        dt.Columns.Add("#ofComment", typeof(long));
        dt.Columns.Add("Average point", typeof(decimal));
        foreach (Reviewer reviewer in allReviewers) {
          dt.Columns.Add(reviewer.ReviewerName, typeof(long));
        }
        foreach (Article article in Articles) {
          DataRow newRow = dt.NewRow();
          newRow["Title"] = article.ArticleTitle;
          newRow["#ofView"] = article.NumberOfView;
          newRow["#ofComment"] = article.NumberOfComment;
          newRow["Average point"] = article.GetAverage();
          foreach (ArticleReview review in article.Reviews) {
            string targetName = review.TheReviewer.ReviewerName;
            for (int i = 4; i < dt.Columns.Count; i++) {
              if (targetName == dt.Columns[i].ColumnName) {
                newRow[review.TheReviewer.ReviewerName] = review.ReviewPoint;
                break;
              }
            }
          }
          dt.Rows.Add(newRow);
        }
        return dt;
      }
      private List<Reviewer> GetNumberOfReviewers() {
        // we need a list of all the different reviewers
        List<Reviewer> reviewers = new List<Reviewer>();
        foreach (Article article in Articles) {
          foreach (ArticleReview review in article.Reviews) {
            if (!reviewers.Contains(review.TheReviewer)) {
              reviewers.Add(review.TheReviewer);
            }
          }
        }
        reviewers.Sort();
        return reviewers; 
      }
    }
