    [ChildActionOnly]
    public ActionResult Cart()
    {
        ViewBag.ItemCount = 2;  // replace hard coded value with your actual value
        return PartialView();
    }
