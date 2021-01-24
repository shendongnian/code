    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
      if (id == null)
      {
        return BadRequest();
        var result = _visitorRepository.GetFromDB(id);
      }
      if (result != null)
        return Ok(result);
      else
        return NotFound();
    }
