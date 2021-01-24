    [HttpGet]
    public async Task<IActionResult> GetUser() {
        //was the header provided?
        var headerValue = Request.Headers["HTTP_JHED_UID"];
        if(headerValue == StringValues.Empty) return BadRequest(); //401
        
        //does the person exist?
        var person = headerValue.ToString();
        if(repository.JhedUserExists(person) == false) return NotFound(); //404
        
        var user = await repository.GetUser(person);
        var userDto = mapper.Map<User, UserForDisplayDto>(user);
        return Ok(userDto); //200
    }
