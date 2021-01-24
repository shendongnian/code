    public async Task<Supplier> GetAsync(int supplierId)
    {
        var supplier = await _context.Suppliers.FindAsync(supplierId);
        if (supplier != null)
        {
            await _context.Entry(supplier)
                .Collection(e => e.Catalogs)
                .Query() // <--
                .Include(e => e.CatalogItems) // <--
                .LoadAsync();
        }
        return supplier;
    }
