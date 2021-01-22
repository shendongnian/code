    public ActionResult Select(string TemplateName)
    {
        if (Request.IsAjaxRequest())
        {
            return Json(TemplateName);
        }
        return View(TemplateName);           
    }
