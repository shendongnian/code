    public async Task<IActionResult> OnGet()
    {
        if (User?.Identity.IsAuthenticated == true)
        {
            await _signInManager.SignOutAsync();          
            return RedirectToPage(); // A redirect ensures that the cookies has gone.
        }
    
        return Page();
    }
