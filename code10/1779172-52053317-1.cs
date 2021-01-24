    [HttpPost("Delete/{id}", Name = "DeleteRoute")]
    [Authorize(Roles = "SuperUser")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        Console.WriteLine("Deleting user: " + id);
        try {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
                // ... 
            await _userManager.DeleteAsync(user);
            return Ok();
        } catch(Exception e) {
            return BadRequest(e.Message);
        }
    }
