    [HttpGet]
    public IActionResult LogIn()
    {
        if (!string.IsNullOrEmpty(Request.QueryString.Value))
            return RedirectToAction("Login");
        return View();
    }
