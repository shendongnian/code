    [HttpPost]
    public async Task<IActionResult> PostUserModel([FromBody] UserModel userModel)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
    
        _context.Users.Add(userModel);
        await _context.SaveChangesAsync();
    
        return CreatedAtAction(nameof(GetUserModel), new {id = userModel.Username}, userModel);
    }
