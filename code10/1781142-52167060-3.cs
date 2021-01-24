    public async Task<IActionResult> Create([Bind("Id,Name,Description,IsActive,DivisionId")] Department department)
    {
        if (ModelState.IsValid)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }
