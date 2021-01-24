    ...
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this._hostingEnvironment = hostingEnvironment;
            this._httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            //read cookie from IHttpContextAccessor 
            string cookieValueFromContext = _httpContextAccessor.HttpContext.Request.Cookies["MyOwnKey"];
            ViewData["CookieFromContext"] = cookieValueFromContext;
            return View();
        }
