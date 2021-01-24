    public IActionResult Test(string id)
    {
        (...)
    
        ViewBag.User = context.Users.First(x => x.Id.ToString() == id);
        ViewBag.Message = "abc";
    
        return View("Edit");
    }
