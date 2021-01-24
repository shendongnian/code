    public IActionResult Test(string id)
    {
        (...)
    
        var user = context.Users.First(x => x.Id.ToString() == id);
        ViewBag.message = "abc";
    
        return View("Edit", user);
    }
