    public IActionResult Users()
    {
        using (var aplicationDbContext = new ApplicationContext())
        {
           var AllUsers = aplicationDbContext.ApplicationUsers.toList(); //return all users not just the first
           return View(AllUsers);
        }
    }
