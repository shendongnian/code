    public async Task<IActionResult> Create()
    {
        var teachers = await _context.Teachers.Where(t => t.Class == null).ToListAsync();
        ViewData["Teachers"] = new SelectList(teachers,"ID","FullName");
        return View();
    }
