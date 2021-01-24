	public async Task<IActionResult> Create([Bind("Id,Description")] TestModel testModel)
    {
        if (ModelState.IsValid)
        {       			
			if(testModel.Id > 0){
				// the entity is already created and it is modify request
				_context.Entry(testModel).State = EntityState.Modified;
								
				testModel.ModifiedBy = this.User.Identity.Name;
				testModel.Modified = DateTime.Now;
			}
			else{
				// it is create request
				_context.Entry(testModel).State = EntityState.Added;			
				
				testModel.CreatedBy = this.User.Identity.Name;
				testModel.Created = DateTime.Now;
			}            
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(testModel);
    }
