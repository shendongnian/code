    public IHttpActionResult User(int id)
    {
        var user = userRepository.GetUserById(id);
        return Ok(username);
    }
