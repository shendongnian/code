    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Class @class)
    {
        if (ModelState.IsValid)
        {
            _context.Classes.Add(@class); // now your @class is containing the `TeacheID` value selected from drop-down.
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View("Index");
    }
