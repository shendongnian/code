    [Authorize(Roles = "Admin")]
    [HttpGet("[action]/{id}")]        
    public User GetUser([FromRoute] int id)
    {
        UserLogic ul = new UserLogic();
        return ul.GetUser(id);
    }
