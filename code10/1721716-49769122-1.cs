    private IHttpContextAccessor _httpContextAccessor;
    public ClientController(IHttpContextAccessor httpContextAccessor)
    {
         _httpContextAccessor = httpContextAccessor;
    }
   
        [Authorize]
    public async Task<IActionResult> ClientUpdate(ClientModel client)
    {
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token"); 
    
        return View();
    }
 
 
