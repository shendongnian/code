    public IActionResult OnPost()
    {
        if (!IsCorrect())
        {
            ModelState.Remove(nameof(Attempts));
            Attempts++;
            return Page();
        }
    
        return RedirectToPage("./Index");
    }
