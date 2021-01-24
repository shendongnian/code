    public IActionResult About()
    {
        // again, this is just a guess 
        if (this.canAccessAbout.Validate())
        {
            return View();
        }
        else
        {
            // redirect them or display error page
        }
    }
