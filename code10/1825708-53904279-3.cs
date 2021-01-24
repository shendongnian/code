    return _context.Companies
                   .Select(c => new CompanyViewModel
                   {
                       ID = c.ID,
                       Name = c.Name,
                       Description = c.Description,
                       CustomID = c.CustomerID
                   })
                   .ToList();
