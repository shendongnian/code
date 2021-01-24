    public async Task<IActionResult> Alerts(int inspectionId) 
    {
        var q = _context.Inspection
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Comments)
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Photos)
                        .Include(i => i.InspectionNotes)
                        .ThenInclude(iN => iN.Videos)
                        .Select(i => new YourViewModel() { 
                              InspectionNotes = i.InspectionNotes,
                              Comments = i.Comments,
                              Id  = i.Id
                        })
                        .Where(c => c.Comments.Alert && c.Id == inspectionId)
                        .ToListAsync();
    
        return View(await q);
    }
