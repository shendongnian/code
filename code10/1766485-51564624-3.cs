    [HttpGet]
    public async Task<IActionResult> UpdateLocation(int id)
    {
        Location locationToBeUpdated =  await _locationService.GetById(id);
        return View(locationToBeUpdated);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateLocation(int id, string address)
    {
       await _locationService.UpdateLocationAddress(id, address);
       return RedirectToAction("Index", "Location");
    }
