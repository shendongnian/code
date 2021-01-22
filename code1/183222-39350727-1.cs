    private readonly OnlineShop.MVC.Controllers.HomeController _controller = 
            new MVC.Controllers.HomeController(null,new UnitOfWork());
        [OneTimeSetUp]
        public void Init()
        {
            var appKeys = new Dictionary<string, object>();
            appKeys.Add("localhost", 1);
            var httpContext = new MockHttpContext(appKeys);
                        
            _controller.ControllerContext = new ControllerContext()
            {
                Controller = _controller,
                RequestContext = new RequestContext(httpContext, new RouteData())    
            };                        
        }
        [Test]
        public void Index_Returns_HomeView()
        {            
            var view = _controller.Index() as ViewResult;
            var viewModel = view.Model as MVC.ViewModels.Home;
           
            Assert.IsInstanceOf<OnlineShop.MVC.ViewModels.Home>(viewModel);
            Assert.IsTrue(viewModel.FeaturedProducts.Count > 0);
        }
