    [BindProperty]
    public BoostNo Boost_No { get; set; }
    
    public IActionResult OnPost()
    {
        return Page();
    }
