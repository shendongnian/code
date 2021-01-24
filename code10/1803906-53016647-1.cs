    public IActionResult Create()
    {
        if(ModelState.IsValid)
        {
            return RedirectToPage("Success"); // redirect as part of PRG
        }
        else
        {
            return Page(); // redisplay the page with validation errors
        }
    }
