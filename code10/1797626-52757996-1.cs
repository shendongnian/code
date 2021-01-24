    [HttpGet]
    public IHttpActionResult GetMember(string id) {
        var membership = _context.Users.SingleOrDefault(c => c.UserName == id);
        if (membership == null)
            return  NotFound();
        return Ok(membership);
    }
