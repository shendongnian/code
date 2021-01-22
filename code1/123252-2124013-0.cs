    public ActionResult Index(string Foo)
    {
        string Action = Request.QueryString["Action"];
        if (Action == "DoThis")
        {
            return Content("Done");
        }
        else
        {
            return Content(Action);
        }
    }
