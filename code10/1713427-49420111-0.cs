    [HttpGet][Route("FindClients")]
        public IHttpActionResult FindClients(string filterField = null, string filterValue = null, 
        string sortProperty = "Id", int? page = null, int pageSize = 50)
        {
            var ctx = new MyDbContext();
            var query = ctx.Clients.AsQueryable();
        
            if (!string.IsNullOrEmpty(filterField) && !string.IsNullOrEmpty(filterValue))
        	query = query.Query(t => t.Contains(filterField, filterValue)).OrderBy(sortProperty);
        
            //  count.
            var clientCount = query.Count();
            int? pages = null;
        
            if (page.HasValue && pageSize > 0)
            {
        	if (clientCount == 0)
        	    pages = 0;
        	else
        	    pages = clientCount / pageSize + (clientCount % pageSize != 0 ? 1 : 0);
            }
        
            if (page.HasValue)
        	query = query.Skip((page.Value-1) * pageSize).Take(pageSize);
        
            var clients = query.ToList();
        
            return Ok(new
            {
        	total = clientCount,
        	pages = pages,
        	data = clients
            });
        }
