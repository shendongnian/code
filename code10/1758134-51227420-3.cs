    public async Task<IActionResult> CreateEntity([Bind("Name, Date1, Type")] CreateEntityModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = new Entity 
            {
                X = model.X...
            };
            await entityService.Create(entity);
            return RedirectToAction(nameof(Index));
        }
        return View("~/Views/MyView");
    }
