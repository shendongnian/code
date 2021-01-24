    [HttpPost]
            public IActionResult Create([FromBody] TodoItem item)
            {
                if (item == null)
                {
                    return BadRequest();
                }
    
                RequestTelemetry requestTelemetry = HttpContext.Features.Get<RequestTelemetry>();
                requestTelemetry.Properties.Add("nameFromBody", item.Name);
    
                _context.TodoItems.Add(item);
                _context.SaveChanges();
    
                return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
            }
    
