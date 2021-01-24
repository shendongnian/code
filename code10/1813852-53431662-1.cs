    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
         if (id == null)
         {
              return NotFound();
         }
         PigeonDetails pigeonDetails = await _context.PigeonDetails
              .Where(m => m.PigeonID == id)
              .SingleOrDefaultAsync();
    
         if (pigeonDetails == null)
         {
              return NotFound();
         }
         return View(pigeonDetails);
    }
