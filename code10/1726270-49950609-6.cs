    [EnableQuery]
    [ODataRoute("customers({key})/people")]
    public async Task<IEnumerable<Customer>> GetPeople([FromODataUri] int key)
    {
        return await _context.Customers
            .Where(m => m.Id == key)
            .Include(m => m.People)
            .ToListAsync();
    }
