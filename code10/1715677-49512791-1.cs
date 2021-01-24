    [ChildActionOnly]
    public ActionResult ActionBName()
    {
        // Generate ViewModel vm
        return PartialView("_NameOfViewB", vm);
    }
