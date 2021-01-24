    public class ArticlesControllerTests {
        private ArticlesController _articlesController;
    
        private Mock<IArticleRepository> _articleRepositoryMock = new Mock<IArticleRepository>();
    
        public ArticlesControllerTests() {
            _articlesController = new ArticlesController(_articleRepositoryMock.Object);
        }
    
        static ArticlesControllerTests() { //<-- static constructor
            AutoMapperInit.Initialize();
        }
        //...
    }
