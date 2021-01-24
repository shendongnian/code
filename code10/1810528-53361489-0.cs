    hostToUpdate.LastModified = DateTime.Now;
    hostToUpdate.LastDateModifiedBy = _userManager.GetUserId(User);
    if (await TryUpdateModelAsync<Host>(
                    hostToUpdate,
                    "Host",
                    s => s.Name, s => s.Description, s => s.Address, 
                    s => s.Postcode, s => s.Suburb, s => s.State, 
                    s => s.LastModified, s => s.LastDateModifiedBy))
            {
                try
                {
                    _context.Update(hostToUpdate);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                // ...
            }
