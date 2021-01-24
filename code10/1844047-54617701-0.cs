    public Task<Product> Details(string id)
    {
        return Task.Run(() =>
        {
            Product employee = db.ProductList
                    .Include(d => d.MappingProductTagList)
                    .ThenInclude(mapping => mapping.Tag)
                    .SingleOrDefault(p => p.Id == id);
            db.Entry(employee).State = EntityState.Detached; // Änderungen werden nicht geprüft.
            return employee;
        });
    }
