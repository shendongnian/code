       //GET: api/customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var queryParams = HttpContext.Request.Query;
            var collection = _context.Customers.FilterByQueryParams(queryParams);
            return await Task.FromResult(collection.ToList());
        }
