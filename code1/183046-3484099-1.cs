    public class Hub
    {
        public string Mode { get; set; }
    }
    [HttpPost]
    public ActionResult Index(Hub hub)
    {
        string hubMode = hub.Mode;
        return View();
    }
