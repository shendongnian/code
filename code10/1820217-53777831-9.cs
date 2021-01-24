    DataTable dt;
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      Category cat = new Category();
      cat.CategoryId = 1;
      cat.CategoryTitle = "Category 1";
      cat.Articles = GetArticles();
      dt = cat.GetDataTable();
      dataGridView1.DataSource = dt;
    }
    private List<Article> GetArticles() {
      List<Article> articles = new List<Article>();
      Article art = new Article(1, "Article 1 Title", 10, 1200, GetReviews(1));
      articles.Add(art);
      art = new Article(2, "Article 2 Title", 32, 578, GetReviews(2));
      articles.Add(art);
      art = new Article(3, "Article 3 Title", 15, 132, GetReviews(3));
      articles.Add(art);
      art = new Article(4, "Article 4 Title", 13, 133, GetReviews(4));
      articles.Add(art);
      art = new Article(5, "Article 5 Title", 55, 555, GetReviews(5));
      articles.Add(art);
      art = new Article(6, "Article 6 Title", 0, 0, GetReviews(6));
      articles.Add(art);
      return articles;
    }
    private ICollection<ArticleReview> GetReviews(int reviewId) {
      ICollection<ArticleReview> reviews = new List<ArticleReview>();
      ArticleReview ar;
      Reviewer Reviewer1 = new Reviewer(1, "Reviewer 1");
      Reviewer Reviewer2 = new Reviewer(2, "Reviewer 2");
      Reviewer Reviewer3 = new Reviewer(3, "Reviewer 3");
      Reviewer Reviewer4 = new Reviewer(4, "Reviewer 4");
      Reviewer Reviewer5 = new Reviewer(5, "Reviewer 5");
      Reviewer Reviewer6 = new Reviewer(6, "Reviewer 6");
      switch (reviewId) {
        case 1:
          ar = new ArticleReview(1, Reviewer1, 15);
          reviews.Add(ar);
          ar = new ArticleReview(1, Reviewer2, 35);
          reviews.Add(ar);
          ar = new ArticleReview(1, Reviewer3, 80);
          reviews.Add(ar);
          ar = new ArticleReview(1, Reviewer5, 55);
          reviews.Add(ar);
          ar = new ArticleReview(1, Reviewer6, 666);
          reviews.Add(ar);
          break;
        case 2:
          ar = new ArticleReview(2, Reviewer1, 50);
          reviews.Add(ar);
          ar = new ArticleReview(2, Reviewer2, 60);
          reviews.Add(ar);
          ar = new ArticleReview(2, Reviewer3, 40);
          reviews.Add(ar);
          break;
        case 3:
          ar = new ArticleReview(3, Reviewer1, 60);
          reviews.Add(ar);
          ar = new ArticleReview(3, Reviewer2, 60);
          reviews.Add(ar);
          ar = new ArticleReview(3, Reviewer3, 80);
          reviews.Add(ar);
          break;
        case 4:
          ar = new ArticleReview(4, Reviewer1, 30);
          reviews.Add(ar);
          ar = new ArticleReview(4, Reviewer2, 70);
          reviews.Add(ar);
          ar = new ArticleReview(4, Reviewer3, 70);
          reviews.Add(ar);
          break;
        case 5:
          ar = new ArticleReview(5, Reviewer3, 44);
          reviews.Add(ar);
          break;
        case 6:
          break;
        default:
          break;
      }
      return reviews;
    }
