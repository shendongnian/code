    public ActionResult Index()
    {
        FileUploadViewModel UploadFile = new FileUploadViewModel();
        return View(UploadFile);
    }
    [HttpPost]
    public ActionResult Index(FileUploadViewModel UploadFile)
    {
    }
