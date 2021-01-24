    [HttpPost]
    public async Task<ActionResult> EditUser(UserEditViewModel model)
    {
        if (ModelState.IsValid)
        {
            // all right, save and redirect to user list including
            // query string parameters.
            return RedirectToAction("UserList", this.Request.QueryString.ToRouteValueDictionary());
        }
        // something wrong with model, return to form
        return View(model);
    }
