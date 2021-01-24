    var result = _context.Companies
                         .Select(c => new 
                         {
                             c.ID,
                             c.Name,
                             c.Description,
                             c.CustomerID
                         })
                         .ToList();
