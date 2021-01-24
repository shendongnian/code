    public ActionResult Edit(int Id)
    {
        using (var applicationContext = new ApplicationContext())
        {
            var User = applicationContext.ApplicationUsers.Where(s => s.Id ==  Id).SingleOrDefault();
            if (User == null)
            {
                return NotFound();
            }
            return View(User);
        }
    }
    [HttpPost, ActionName("Edit")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditPost(ApplicationUser user)
    {
        //Here will return every time NotFound/error, right? Where you defined Name?!
        /*if (Name == null)
        {
            return NotFound();
        }*/
        using (var applicationContext = new ApplicationContext())
        {
            var UserUpdate = await applicationContext.ApplicationUsers.SingleOrDefaultAsync(s => s.Id == user.Id);
    ...
