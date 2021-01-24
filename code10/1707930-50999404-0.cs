        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind("Id,Role")] RoleViewModel pRole)
        {
            if (id != pRole.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var role = await _roleManager.FindByIdAsync(pRole.Id);
                    role.Name = pRole.Role;
                    var result = await _roleManager.UpdateAsync(role);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", result.Errors.First().ToString());
                        return View();
                    }
                    return RedirectToAction("Index");
                } catch (Exception)
                {
                    throw;
                }
            }
            return View(pRole);
        }
