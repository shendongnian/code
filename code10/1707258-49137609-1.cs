    public IHttpActionResult GetUsers()
    {
        var users = _service.GetUsers()
        var model = new UserResponse(users);
        return Ok(model);
    }
