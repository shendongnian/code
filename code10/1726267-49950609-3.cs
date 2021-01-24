    [EnableQuery]
    [ODataRoute("customers({key})/people")]
    public async Task<IActionResult> GetPeople([FromODataUri] int key)
    {
        var customers = await _context.Customers
            .Where(m => m.Id == key)
            .Include(m => m.People)
            .ToListAsync();
        // this is only an example
        if (!customers.Any())
        {
            return NotFound();
        }
        return Json(customers);
    }
