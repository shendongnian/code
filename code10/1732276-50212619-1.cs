    private readonly IOptions<SettingsOptions> options;
            public HomeController(IOptions<SettingsOptions> options)
            {
                this.options = options;
            }
            
            public IActionResult Index()
            {
                var value = options.Value;
                ViewBag.Index = value.PropA+"success";
                return View();
            }
