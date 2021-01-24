    private readonly IGameApiService _apiService;
    public DepartmentController(IGameApiService apiService)
    {
        _apiService = apiService;
    }
    [HttpGet]
    public async Task<IActionResult> Department()
    {
        ViewData["Name"] = User.Claims.FirstOrDefault(c => c.Type == JwtClaimTypes.Name)?.Value;
        var (response, content) = await _apiService.GetDepartments();
        if (!response.IsSuccessStatusCode) return Forbid();
        return View(JsonConvert.DeserializeObject<Department[]>(content));
    }
    [HttpGet]
    public async Task<IActionResult> DepartmentEdit(string id)
    {
        ViewData["id"] = id;
        var (response, content) = await _apiService.GetDepartmenById(id);
        if (!response.IsSuccessStatusCode) return Forbid();
        return View(JsonConvert.DeserializeObject<Department>(content));
    }
