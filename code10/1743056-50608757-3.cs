    public async Task<IActionResult> OnPostAsync()
    {
        if (HandlerMap.TryGetValue(option, out var algorithm))
        {
             algorithm(input);
        }
        // .. else this isn't a valid option.
    }
