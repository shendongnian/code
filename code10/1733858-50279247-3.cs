    [HttpPost]
    public IActionResult Create(CreateStationViewModel model)
    {
        if (ModelState.IsValid)
        {
            // You build the entity model from the view model
            _context.Stations.Add(new Station
            {
                Code = model.Code,
                Name = model.Name,
                StateId = model.SelectedStateId
            });
            _context.SaveChanges();
           return RedirectToAction("index");
        }
        // Rebuild the available states, or 
        // better, you can use ajax for the whole form (different topic)
        model.AvailableStates = _context.States
                .ToDictionary(x => x.Id, x => $"{ x.Name }({ x.Code })");
        return View(model);
    }
