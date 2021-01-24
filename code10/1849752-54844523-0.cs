       //GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var queryParams = HttpContext.Request.Query;
            var collection = _context.Customers.Take(20).FilterByQueryParams(queryParams);
            return await Task.FromResult(collection.ToList());
        }
