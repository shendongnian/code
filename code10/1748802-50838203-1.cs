    [HttpGet]
    public IActionResult UserDetail(int id, string message)
    {
       // Code to GET the UserViewModel
       return View(model);
    }
