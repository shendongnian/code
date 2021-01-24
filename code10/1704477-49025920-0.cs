        public class ArticleListingController : ApiController
        {
             private readonly IArticleProvider _newsarticleProvider;
             public ArticleListingController(IArticleProvider newsarticleProvider)
             {
                 _newsarticleProvider = newsarticleProvider ?? throw new ArgumentNullException(nameof(newsarticleProvider));  
             }
         }
