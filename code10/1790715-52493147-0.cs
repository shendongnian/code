    public ICollection<Form> GetFormWithNonDeletedProducts(string scode)
    {
        using (var dbContext = new MyDbContext(...))
        {
            return dBContext.Forms                      // from the collection of all Forms
                .Where(form => form.Code == fCode      
                        && form.SCode == sCode)         // keep only the ones that I want
                .Select(form => new Form()              // and create a new Form object
                {                                       // with the properties I plan to use
                     Id = form.Id,
                     Name = form.Name,
                     ...
                     Products = form.Products           // Fetch only the non-deleted products
                         .Where(product => !product.Deleted)
                         .ToList(),
                }
                .FirstOrDefault();
            }
        }
    }
