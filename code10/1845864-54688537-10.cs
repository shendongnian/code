    [HttpPost]
    public async Task<ActionResult> CreateRole(RoleViewModel roleViewModel)
    {
        if (ModelState.IsValid)
        {
            var role = new ApplicationRole(roleViewModel.Name);
            role.Description = roleViewModel.Description; // <--- Here you have to assign the `Description` value
            var roleresult = await RoleManager.CreateAsync(role);
            if (!roleresult.Succeeded)
            {
                ModelState.AddModelError("", roleresult.Errors.First());
                return View();
            }
            return RedirectToAction("Index");
        }
        return View();
    }
