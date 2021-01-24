    [HttpGet]
    public async Task<IActionResult> GetPeople()
    {
        var data = await _context.People
            // select the data you want directly
            .Select(p => new PersonInfo 
            { 
                id = p.id, 
                FirstName = p.FirstName, 
                LastName = p.LastName, 
                AD = p.AD
            })
            // always use the asynchronous version of EF Core extension methods
            .ToListAsync();
        return Json(data);
    }
