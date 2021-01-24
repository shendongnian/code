    if (await TryUpdateModelAsync(
        adminUpdate,
        "",
        a => a.FirstName,
        a => a.LastName,
        a => a.Email,
        a => a.Status,
        a => a.CompanyId
        ))
    {
        adminUpdate.Password = password;
        await _context.SaveChangesAsync();
        return Redirect("/admin");
    }
