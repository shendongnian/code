    [HttpPost]
    public async Task<ActionResult> CreateRole(RoleViewModel roleViewModel)
    {
        if (ModelState.IsValid)
        {
            var role = new ApplicationRole(roleViewModel.Name);
     
            role.Description = roleViewModel.Description; // <--- Here you have assign the Description value
            IdentityResult result = await roleManager.CreateRoleAsync(role); // <-- call your repository method here.
            if (!roleresult.Succeeded)
            {
                ModelState.AddModelError("", roleresult.Errors.First());
                return View();
            }
            return RedirectToAction("Index");
        }
        return View();
    }
