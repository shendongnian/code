    [Authorize]
    [HttpGet]
    public async Task<ActionResult> Index()
    {
        ViewBag.sessionv = HttpContext.Session.GetInt32("idMember");
        FileMakerRestClient client = new FileMakerRestClient(serverName, fileName, userName, password);
        var toFind = new Models.EventsLines { Zkf_CTC = 1053 };
        var results = await client.FindAsync(toFind);
        var xtoFind = new Models.SubEventsLines { Zkf_CTC = 1053 };
        var xresults = await client.FindAsync(xtoFind);
        Models.EventViewModel oEventViewModel = new Models.EventViewModel
        {
            _EventsLines = (from o in results select o).ToList(),
            _SubEventsLines = (from x in xresults select x).ToList()
        };
        ViewBag.Zkf_CTC = 1053;
        return View(oEventViewModel);
    }
