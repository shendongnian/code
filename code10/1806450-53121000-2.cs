    public ActionResult MyView(string SavedMessage)
    {
        //Maybe some code here
        ViewBag.SavedMessage = SavedMessage;
        return View();
    }
