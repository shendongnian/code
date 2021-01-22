    [HttpPost, PassState]
    public ActionResult Update(EntityType entity)
    {
        // Only update if the model is valid
        if (ModelState.IsValid) {
            base.Update(entity);
        }
        // Always redirect to Detail view.
        // Any errors will be passed along automagically, thanks to the attribute.
        return RedirectToAction("Detail", new { id = entity.Id });
    }
    [HttpGet, GetState]
    public ActionResult Detail(int id)
    {
        // Get stuff from the database and show the view
        // The model state, if there is any, will be imported by the attribute.
    }
