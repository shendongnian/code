    public async Task<IActionResult> Index()
    {
        var result = await authenticationClient.GetData();
        return View(result);
    }
