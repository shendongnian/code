    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var httpClient = _httpClientFactory.CreateClient(ConstantNames.WebApi);
        var response = await httpClient.PostAsJsonAsync($"{ApiArea}/authenticate", model);
        if (response.IsSuccessStatusCode)
        {
            var jwtToken = await response.Content.ReadAsAsync<JWTToken>();
    
            var username = ...
            var others = ...
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                // add other claims as you want ...
            };
            var iden= new ClaimsIdentity( claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(iden);
            await HttpContext.SignInAsync( CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return Redirect("/")
    
        }
        else
        {
            ModelState.AddModelError("Password", "Invalid password");
            model.Password = "";
            return View(model);
        }
    
        return RedirectToAction("Index", "Home");
    }
