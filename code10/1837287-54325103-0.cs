    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid && Table != null)
        {
            try
            {
                Table.GameData = DateTime.Now;
                _context.Tables.Add(Table);
                await _context.SaveChangesAsync();
             }
             catch(Exception)
             {                 
                 ModelState.AddModelError("Table", "exc1");  
                 return Page();                  
             }             
       } 
       else
       {
           return Page();
       }
       return RedirectToAction("OnGetAsync");                     
     }
