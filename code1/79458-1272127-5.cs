    public ActionResult Details(string action2, string id)
    {
        switch (action2)
        {
            case "edit":
                // Do Something.
                return View("edit");
            case "view":
                // Do Something.
                return View("view");
           default :
                // Do Something.
                return View("bad-action-error");
        }
    }
