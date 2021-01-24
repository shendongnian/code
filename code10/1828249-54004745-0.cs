    [HttpPost]
    public IActionResult PostNewUser([FromBody]UserDto userDto) {
        if (userDto == null)
            return BadRequest(nameof(userDto));
        IUsersService usersService = GetService<IUsersService>();
        var id = usersService.Add(userDto);
        //construct desired URL
        var url = string.Format("api/users/{0}",id.ToString());
        return Created(url, id.ToString());
    }
    
