    [HttpPut("Test/{id}")]
    public IActionResult PutTest(string id, byte[] file)
    {
        //rest of method
        return StatusCode(201);
    }
