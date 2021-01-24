    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
 
        if (ModelState.IsValid)
        {
            return View(model); 
        }
        // check for duplicates
        bool combinationExists = await _context.Users
            .AnyAsync(x => x.UserName == model.UserName 
                     && x.Email == model.Email
                     && x.TenantId == model.TenantId);
        if (combinationExists)
        {
            return View(model);
        }
        // create the user otherwise
    }
