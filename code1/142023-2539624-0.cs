    public ActionResult Section1()
    {
        if (Request.IsAjaxRequest())
        {
            return PartialView("section1.ascx");
        }
    
        return View("section.aspx");
    }
