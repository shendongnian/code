    public ActionResult Index()
    {
    Serilog.Log.Information("this is the first log information created by serilog");
    return View();
    }
