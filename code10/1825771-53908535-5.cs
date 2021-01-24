    public async Task<IActionResult> Attending(int cID, int eID, int check)
    {
        var guest = await _context.Guests
                                  .Where(g => g.CustomerId == cID 
                                           && g.EventId == eID)
                                  .FirstOrDefaultAsync();
        if(guest!=null)
        {
           guest.IsActive = check == 0;
           try
           {
               _context.Update(guest);
               await _context.SaveChangesAsync();
           }
           catch (Exception ex)
           {
              // Make sure to log the exception and not leak the ToString version to client.
              return Json(new { status = false, message = ex.ToString() });
           }
           return Json(new { status = true, message = "Updated" });
        }
        return Json(new { status = false, message = "Customer not found!" });
    }
