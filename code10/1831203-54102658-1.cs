    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SalesClerkIds")] Plant plant)
    {
        if (id != plant.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                Plant plantToBeUpdated = await _context.Plants.Include(p => p.SalesClerks).FirstOrDefaultAsync(p => p.Id == id);
                plantToBeUpdated.SalesClerks.Clear(); // Here you have to clear the existing children before adding the new
                if (plant.SalesClerkIds.Count > 0)
                {
                    foreach (var scId in plant.SalesClerkIds)
                    {
                        plantToBeUpdated.SalesClerks.Add(new PlantSalesClerk()
                        {
                            PlantId = plantToBeUpdated.Id,
                            UserId = scId
                        });
                    }
                }
                 plantToBeUpdated.Name = plant.Name;
                 // Map other properties here if any
                _context.Plants.Update(plantToBeUpdated);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(plant.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(plant);
    }
