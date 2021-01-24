    using (var dbContext = new MyDbContext(...))
    {
        return dBContext.Forms                  // from the collection of all Forms
            .Where(form => form.Code == fCode      
                && form.SCode == sCode)         // keep only the ones that I want
            .Select(form => new                 // and create a new Form object
            {                                   // with the properties I plan to use
                     Id = form.Id,
                     Name = form.Name,
                     ...
                     Products = form.Products   // Fetch only the non-deleted products
                         .Where(product => !product.Deleted)
                         .Select(product => new
                          {                     // Select only properties you plan to use
                              Name = product.Name,
                              Price = product.Price,
                              // not meaningful: you already know the value:
                              // FormId = product.FormId,
                          })
                         .ToList(),
            }
            .FirstOrDefault();
    }
