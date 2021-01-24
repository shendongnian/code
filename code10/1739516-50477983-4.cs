    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody]string employee)
    {
        var user = new Employee { UserName = "test@gmail.com", Email = "test@gmail.com" };
        var d = await userManager.CreateAsync(user, "1234567");
        if (d == IdentityResult.Success)
        {
            return Ok();
        }
        else 
        {
            return BadRequest(d);
        }
    }
