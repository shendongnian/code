    [HttpDelete]
    [Route("api/users/{userId}/roles/{roleName}")]
    public async Task<IHttpActionResult> RemoveFromRole(string userId, string roleName) {
        var userInDb = _identity.Users.FirstOrDefault(user => user.Id == userId);
        if (userInDb == null)
            return NotFound();
            
        //get user's assigned roles
        IList<string> userRoles = await _userManager.GetRolesAsync(userId);
        
        //check for role to be removed
        var roleToRemove = userRoles.FirstOrDefault(role => role.Equals(roleName, StringComparison.InvariantCultureIgnoreCase));
        if (roleToRemove == null)
            return NotFound();
        var result = await _userManager.RemoveFromRoleAsync(userId, roleToRemove);
        if(result.Succeeded)
            return Ok();
            
        return BadRequest();
    }
    
