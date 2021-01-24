    [HttpPost("Create")]
    public async Task Create([FromBody]string employee)
    {
        var user = new Employee { UserName = "test@gmail.com", Email = "test@gmail.com" };
        var d = await userManager.CreateAsync(user, "1234567");
    }
