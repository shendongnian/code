    if (ModelState.IsValid)
    {
        try
        {
            _context.Add(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is SqlException innerException)
            {
                // handle exception here..
                ModelState.AddModelError("Col1", yourmessage1);
            }
            else
            {
                ModelState.AddModelError("Col1", yourmessage2);
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("Col1", ex.Message);
        }
    }
    return View();
