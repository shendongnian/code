    public async Task<IActionResult> GetAllJobsAsync(int Id)
    {
        using (var _db = new FuelCallManagmentEntities())
        {
            var alljobs = await _db.Jobs.Where(w => w.EngineerId == Id).ToListAsync();
            return Ok(alljobs);
        }
    }
