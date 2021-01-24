    public async Task<IActionResult> OnPostCreateAsync()
    {
            
        var option = new CookieOptions();
        option.Expires = DateTime.Now.AddMinutes(10);
        Response.Cookies.Append("Emailoption", "true", option);
        return RedirectToPage();
    }
