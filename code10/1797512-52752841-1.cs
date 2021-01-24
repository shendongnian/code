    public async Task<IActionResult> Index()
    {
        var result = await GetList();
        return View(result);
    }
