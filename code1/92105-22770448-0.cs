    public class Article
    {
        public void AddComment(Comment comment, IAddCommentProcessor commentProcessor)
        {
            commentProcessor.AddComment(this, comment);
        }
    }
    public interface IAddCommentProcessor
    {
        void AddComment(Article article, Comment comment);
    }
    public class AddCommentAndEmailProcessor : IAddCommentProcessor
    {
        private readonly _emailService;
        public AddCommentAndEmailProcessor(EmailService emailService)
        {
            _emailService = emailService;
        }
        public void AddComment(Article article, Comment comment)
        {
            // Add Comment
            
            // Email
            _emailService.SendEmail(App.Config.AdminEmail, "New comment posted!");
        }
    }
    public class ArticleController
    {
        private readonly IRepository _repository;
        private readonly IArticleService _articleService;
        public ArticleController(IRepository repository, IArticleService articleService)
        {
            _repository = repository;
            _articleService = articleService;
        }
        public void AddComment(int articleId, Comment comment)
        {
            var article = _repository.Get<Article>(articleId);
            article.AddComment(comment, new AddCommentAndEmailProcessor(ServiceLocator.GetEmailService())); // Or you can use DI to get the Email Service, or any other means you'd prefer
            _repository.Save(article);
            return RedirectToAction("Index");
        }
    }
