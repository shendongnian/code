    [HttpPost]
    public async Task<IActionResult> Add(FunwarsVM model, List<IFormFile> images)
    {
        model.Add();
        return RedirectToAction("Index",model);
    }
