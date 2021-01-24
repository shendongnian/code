    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        Location locationToBeUpdated =  await _locationService.GetById(id);
        return View(locationToBeUpdated);
    }
