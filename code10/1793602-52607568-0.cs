    [AllowAnonymous]
    [HttpPost]
    public IActionResult Index(User user)
    {
        try
        {
    		var currentUser = _UserService.login(user, _context);                
    		if (currentUser.userID != 0)
    		{                                        
    			var claims = new List<Claim>
    			{
    				new Claim(ClaimTypes.Name, currentUser.NAME_SURNAME),                                                
    				new Claim(ClaimTypes.Role, "Admin")      
    			};
    
    			var claimsIdentity = new ClaimsIdentity(
    				claims, CookieAuthenticationDefaults.AuthenticationScheme);
    
    			var authProperties = new AuthenticationProperties
    			{
    				ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
    			};
    
    			await HttpContext.SignInAsync(
    				CookieAuthenticationDefaults.AuthenticationScheme, 
    				new ClaimsPrincipal(claimsIdentity), 
    				authProperties);
    				
    			return RedirectToAction("index", "home");
    		}
    		else
    		{
    			TempData["error"] = "Kullanıcı adı yada şifre yanlıştır.";
    			return RedirectToAction("index", "home");
    		}                    
        }
        catch(Exception ex){
            TempData["error"] = ex.Message;
            //TempData["error"] = "User not found.";
            return RedirectToAction("index", "home");
        }
    } 
