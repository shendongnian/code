    public IActionResult OnPost()
    {       
        this.Price = 25;
        ModelState.Remove("Price");  // This line does the trick
        return Page();
    }
