    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();  // <-- model error
        }
        // continue with your post logic...
