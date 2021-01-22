    [HttpPost]
    [MultiButton(MatchFormKey="action", MatchFormValue="Cancel")]
    public ActionResult Cancel()
    {
        return Content("Cancel clicked");
    }
    [HttpPost]
    [MultiButton(MatchFormKey = "action", MatchFormValue = "Create")]
    public ActionResult Create(Person person)
    {
        return Content("Create clicked");
    } 
