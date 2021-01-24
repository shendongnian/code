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
                plantToBeUpdated.SalesClerks.Clear();
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
