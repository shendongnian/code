    // POST: /Duty/Edit/5 
 
    [HttpPost] 
    public ActionResult Edit(Duty Model) 
    { 
        ctx.AttachTo("Duties", Model); 
        ctx.UpdateObject(Model); 
        ctx.SaveChanges(); 
        return RedirectToAction("Index"); 
    } 
