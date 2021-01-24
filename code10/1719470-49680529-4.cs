    [System.Web.Http.HttpGet]          
    public UserDto Get()
    {            
        return new UserDto()
        {
            ID = 1,
            DateOfBirth = DateTime.UtcNow,
            Email = "test",
            Name = "name"
        };
    }
