    public async Task<IActionResult> OnPostAsync(string id)
    {
        ApUser = await _userManager.FindByIdAsync(id);
        if (!ModelState.IsValid)
        {
            return Page();
        }
        ApUser.Email = Input.Email;
        ApUser.Score = Input.Score;
        ApUser.Sequence = Input.Sequence;
        ApUser.Position = 0;
        await _userManager.UpdateAsync(ApUser);
        Message = ApUser.Email;
        return RedirectToPage("Index");
    }
