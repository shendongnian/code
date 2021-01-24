        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "UsersEditRolesPost")]
        public async Task<IActionResult> EditRoles(string id, RolesEditViewModel vm)
        {
            if (String.IsNullOrEmpty(id))
            {
                return RedirectToAction("ErrorBadRequest", "Errors");
            }
            var userExists = _users.UserExists(id);
            if (!userExists.Item1)
            {
                return RedirectToAction("NotFound", "Errors", new { id = userExists.Item2 });
            }
            if (ModelState.IsValid)
            {
                await _users.UpdateUserRolesStatusAsync(id, vm);
                return RedirectToAction("Details", "Users", new { id = vm.UserId });
            }
            return View(vm);
        }
