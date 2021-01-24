    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UserForUpdateDto userDto) 
       {    
           var sub = User.GetSubjectId();   // Subject Id is the user id
        }
