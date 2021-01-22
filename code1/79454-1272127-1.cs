    public ActionResult Details(string action2, string id)
    {
        switch (action2)
        {
            case "edit":
                // Do Something.
                return View("edit");
           default :
                // Do Something.
                return View("view");
        }
    }
