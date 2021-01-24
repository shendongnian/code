    public async Task<IActionResult> Alerts(int inspectionId) 
    {
        var q = _context.Inspection
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Comments)
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Photos)
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Videos)
                        .Where(c => c.Alert && c.Id == inspectionId)
                        .Select(i => new YourViewModel() { 
                              InspectionNotes = i.InspectionNotes,
                              Comments = i.Comments
                        })
                        .ToListAsync();
    
        return View(await q);
    }
