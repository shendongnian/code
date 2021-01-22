    [HttpPost]
    public ActionResult Detail(Application entity)
    {
        base.Update(entity);
        if (ModelState.IsValid)
        {
            //Save the entity here
        }
       return View("Detail", new { id = entity.Id });
    }  
