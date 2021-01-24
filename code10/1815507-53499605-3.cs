    public ActionResult<IEnumerable<User>> GetAll()
    {
        var list = _userRepository.GetAll();
        var model = new Result<User>
        {
            StatusCode = 200,
            Count = list.Count,
            Data = list
        };
    
        return Ok(model);
    }
