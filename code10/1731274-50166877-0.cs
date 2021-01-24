    [HttpPost]
    public IActionResult Upload(string office, IFormFile file)
    {
        return RedirectToAction("Index", new{office = office});
    }
