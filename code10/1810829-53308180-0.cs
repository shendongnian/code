    //note controller actions will default to HttpGet if no data annotation is explicitly supplied. Also, action names generally begin uppercase by convention
    public ActionResult SomeAction(string category, string id = null)
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            return View("viewOne");
        }
        else
        {
            return View("ViewTwo");
        }
    }
