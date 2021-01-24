    var hostToUpdate = await _context.Host.SingleOrDefaultAsync(s => s.Id == id);
    hostToUpdate.LastModified = DateTime.Now;
    hostToUpdate.LastDateModifiedBy = _userManager.GetUserId(User);
    if (await TryUpdateModelAsync(
        hostToUpdate,
        "", // Do you need to set Host here?
        s => s.Name, s => s.Description, s => s.Address, 
        s => s.Postcode, s => s.Suburb, s => s.State))
    {
        try
        {
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        // ...
    }
