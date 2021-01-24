    public IActionResult Login()
    {
        if (Request.Path.StartsWithSegments("/test_environment"))
        {
            return Redirect("/");
        }
        else
        {
            return Redirect("/test_environment/");
        }
    }
