    public IActionResult Test(string id)
    {
        var user = context.Users.First(x => x.Id.ToString() == id);
        var message = "abc";
        return View("Edit", (user, message));
    }
