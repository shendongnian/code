    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUser(int id)
    {
      if(!User.IsInRole("Super user") && !User.IsInRole("Admin") && User.Identity.Name != "Basic User")
      {
         return Unauthorized
      }
      Logic from before
    }
