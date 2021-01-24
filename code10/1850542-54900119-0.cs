    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly string _myTemplatePath;
    public HomeController(IHostingEnvironment hostingEnvironment)
    {
        _hostingEnvironment = hostingEnvironment;
        _myTemplatePath = Path.Combine(_hostingEnvironment.ContentRootPath, @"Views\Shared\_MyTemplate.cshtml");
    }
    public IActionResult Index()
    {
        var myTemplateCode = System.IO.File.ReadAllText(_myTemplatePath); 
        return View(new MyTemplateViewModel
        {
            TemplateCode = myTemplateCode
        });
    }
    [HttpPost]
    public IActionResult UpdateMyTemplate(MyTemplateViewModel viewModel)
    {
        System.IO.File.WriteAllText(_myTemplatePath, viewModel.TemplateCode);
        return RedirectToAction(nameof(Index));
    }
    public IActionResult GetMyTemplate()
    {
        return View("_MyTemplate");
    }
