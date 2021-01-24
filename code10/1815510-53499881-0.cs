    public ActionResult<IEnumerable<object>> GetAll()
    {
        var list = _userRepository.GetAll(); // <-- if this is not (yet) an Array or a List, then force single evaluation by adding .ToArray() or .ToList()
        var model = new
        {
            statuscode = 200,
            count = list.Count, // or .Length if list is an Array
            data = list.Select(x => new { name = x.name, username = x.userName })
        };
        return Ok(model);
    }
