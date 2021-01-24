    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
         if (id == null)
         {
              return NotFound();
         }
         var pigeonDetails = await _context.PigeonDetails.SingleOrDefaultAsync(m => m.PigeonID == id);
    
         if (pigeonDetails == null)
         {
              return NotFound();
         }
         return View(pigeonDetails);
    }
