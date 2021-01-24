    [System.Web.Http.HttpGet]          
    public IHttpActionResult Get()
    {            
        return Json(new UserDto()
        {
            ID = 1,
            DateOfBirth = DateTime.UtcNow,
            Email = "test",
            Name = "name"
        });
    }
