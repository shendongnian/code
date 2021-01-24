       [HttpGet("GetDirector/{id}")]
        public async Task<IActionResult> GetDirector([FromRoute] int id)
        {
            var director =  from p in _context.Employees where p.EmployeeId == KPContext.GetDirectorID(id) select p;
    
            if (director == null )
            {
                return NotFound();
            }
    
            return Ok(director);
        }
