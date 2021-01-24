    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var data = await _repo.GetEmployee(id);
    
        if (data == null) 
        {
            return NotFound();
        }
        
        return Ok(data.ToDto());
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllEmployee()
    {
        var data = await _repo.GetAllEmployee();
    
        return Ok(data.Select(x => x.ToDto()));
    }
