    [Authorize(Roles="CanAddContent")]
    public ActionResult CreateContent(Guid contentOwnerId)
    {
        var viewModel = new ContentViewModel
        {
            ContentOwnerId = contentOwnerId
            //populate rest of view model
        }
        return View("CreateContent", viewModel);
    }
    
    [Authorize(Roles="CanAddContent"), HttpPost, HttpParamAction("CreateContent"), ValidateAntiForgeryToken]
    public ActionResult SaveDraft(ContentFormModel model)
    {
        //Save as draft
        return RedirectToAction("CreateContent");
    }
    
    [Authorize(Roles="CanAddContent"), HttpPost, HttpParamAction("CreateContent"), ValidateAntiForgeryToken]
    public ActionResult Publish(ContentFormModel model)
    {
        //publish content
        return RedirectToAction("CreateContent");
    }
