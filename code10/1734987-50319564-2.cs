    public async Task<IActionResult> EditAsManager(...)
    {
        .....
        await UpdateMemberAsync(...);
    }
    public async Task UpdateMemberAsync(...)
    {
        await _userManager.UpdateNormalizedEmailAsync(member);
    }
