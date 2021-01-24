    [EnableQuery]
    [ODataRoute("customers({key})/people")]
    public IEnumerable<Customer> GetPeople([FromODataUri] int key)
    {
        return _context.Customers
            .Where(m => m.Id == key)
            .Include(m => m.People)
            .ToList();
    }
