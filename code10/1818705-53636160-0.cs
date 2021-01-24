       public async Task<IActionResult> OnPostAsync(int? id)
        {
    
            if (!ModelState.IsValid)
            {
                Customer = await _context.Commercial
                .Include(c => c.Sites)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync(m => m.ID == id);
                ViewData["ModelIsValid"] = false;
                return Page();
            }
            ViewData["ModelIsValid"] = true;
            _context.Address.Add(Site);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");  
        }
