    public async Task<IActionResult> OnGet()
    {
        // need to validate if account exists first
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }
        var domainName = user.Office365DomainName;
        var id = user.Id;
        AzureTableConnection azureTableConnection = new AzureTableConnection();
        Result = await azureTableConnection.TenantLookupAsync(azureTableConnection, domainName, id);
        return Page();
    }
