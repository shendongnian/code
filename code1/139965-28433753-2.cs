For objects that implement `IValidatableObject`, when we check the ModelState, we can also check to see if the model itself is valid before returning the list of errors.  We can add any errors we want by calling ModelState.AddModelError(*field*, *error*).  As specified in [How to force MVC to Validate IValidatableObject][6], we can do it like this:
    [HttpPost]
    public ActionResult Create(Model model) {
        if (!ModelState.IsValid) {
            var errors = model.Validate(new ValidationContext(model, null, null));
            foreach (var error in errors)                                 
                foreach (var memberName in error.MemberNames)
                    ModelState.AddModelError(memberName, error.ErrorMessage);
    
            return View(post);
        }
    }
