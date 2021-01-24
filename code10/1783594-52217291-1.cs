    [HttpGet]
    [Route("ById/{id=id}")]
    public IHttpActionResult GetUser(int? id)
    {
        if (id == null)
            return NotFound();
    
        User user = _context.Users.SingleOrDefault(c => c.UserId == id.Value);
    
        if (user == null)
            return BadRequest("User not exist in our database");
    
        var returnedData = new { FirstName = user.FirstName, LastName = user.LastName, UserName = user.UserName, CreatedAt = DateTime.Now, ModifiedAt = DateTime.Now };
        return Ok(returnedData);
    }
