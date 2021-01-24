    [HttpPost]
    public IActionResult Edit(EditClassAViewModel model)
    {
        var response = new JsonResponse();
        if (!ModelState.IsValid)
        {
            response.AddModalStateErrors(ModelState);
            return Json(response);
        }
        // Get the ClassA entity from the database and convert the persistence
        // model to your domain model. You could have your repository to do
        // both in one step.
        var classAEntity = _dbContext.ClassAs
            .AsNoTracking()
            .SingleOrDefault(x => x.Id == model.ClassAId);
        if (classAEntity == null)
        {
            response.AddError(...);
            return Json(response);
        }
        // Convert the persistence model to domain model. You could use
        // AutoMapper to do so.
        var classA = new ClassA(...);
        // Class the ClassA domain model UpdateDetails method
        classA.UpdateDetails(...);
        // Convert the domain model back to persistence model
        // and save it to the database. You could have your repository to do
        // both in one step.
        var classAPersistenceModel = ...;
        // Since this persistence model is not tracked by EFCore,
        // you need to fetch the entity again from database by Id and update
        // that entity instead.
        // Again, you could have your repository to do that in one step too.
        classAEntity = _dbContext.ClassAs.Find(classAPersistenceModel.Id);
        if (classAEntity != null)
        {
            _dbContext.Entry(classAEntity).CurrentValues
                .SetValues(classAPersistenceModel);
            _dbContext.SaveChanges();
        }
    }
