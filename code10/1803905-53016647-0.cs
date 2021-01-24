    public async Task OnGet()
    {
        HeaderInfo = await _helper
            .GetContentItemByAliasAsync("alias:fullwidth");
    }
