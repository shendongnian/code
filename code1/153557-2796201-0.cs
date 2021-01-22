    [HttpPost]
    public ActionResult Index(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            ModelState.AddModelError("Email", "Should not be empty or invalid");
        }
        return View();
    }
