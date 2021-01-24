    public async Task<IActionResult> Index()
        {
            var result = await _authenticationClient.GetDataAsync();
            return View();
        }
