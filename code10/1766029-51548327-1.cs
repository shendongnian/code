    public async Task<IActionResult> Index()
    {
        var query = 
            from msys in _context.SystemParts
            let childCount = _context.SystemParts.Count(x => x.PartLevel == msys.PartID)
            select new SystemPartViewModel
            {
                PartId = msys.PartID,
                PartName = msys.PartName,
                PartLevel = msys.PartLevel,
                ChildCount = childCount
            };
        return View(await query.ToListAsync());
    }
