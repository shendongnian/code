    public IActionResult Index()
    {
        var result = GetList();
        return View();
    }
    
    public async Task<List<string>> GetList()
    {
        HttpResponseMessage response = await client.GetAsync("GetList");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsAsync<List<string>>();
        }
        return new List<string>();
    }
