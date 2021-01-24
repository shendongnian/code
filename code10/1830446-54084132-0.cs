    [HttpPost]
    public ActionResult Register(string email, string password) 
    {
        if (condition) // put your condition here
        {
            return Json(new { 
                status = "Success", 
                url = Url.Action("Main", "Pages")
            });
        }
        // since this controller receives AJAX request, the partial view should be used instead
        return PartialView("_Register");
    }
