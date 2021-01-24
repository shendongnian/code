    [HttpGet("users/{pageNumber:int}/{pageSize:int}")]
    [Produces(typeof(List<UserViewModel>))]
    public async Task<IActionResult> GetUsers(int pageNumber, int pageSize)
    {
        var users = await _accountManager.GetUsersLoadRelatedAsync(pageNumber, pageSize);
        return Ok(Mapper.Map<List<UserViewModel>>(users));
    }
