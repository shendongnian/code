    [HttpPost]
    public async Task<ActionResult> EditUser(UserEditViewModel model)
    {
        if (ModelState.IsValid)
        {
			var qs = this.Request.QueryString;
            var routeValues = new RouteValueDictionary();
            foreach (string key in qs.AllKeys)
            {
                routeValues[key] = qs[key];
            }
            // all right, save and redirect to user list including
            // query string parameters.
            return RedirectToAction("UserList", routeValues);
        }
        // something wrong with model, return to form
        return View(model);
    }
