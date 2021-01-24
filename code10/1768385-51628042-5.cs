    public class HomeController : Controller
    {
        private CreateReportFactoryDelegate _createReportFactoryDelegate;
    
        public HomeController(CreateReportFactoryDelegate createDelegate) {
            this._createReportFactoryDelegate = createDelegate;
            // ...
        }
    
        public async Task<IActionResult> CacheGetOrCreateAsync() {
    
            IReportFactory reportFactory = this._createReportFactoryDelegate(this.HttpContext);
            var x=reportFactory.Create();
    
            // ...
            return View("Cache", cacheEntry);
        }
    }
