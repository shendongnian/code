    [HttpPost]
    public IActionResult Post(string email)
    {
        if (ModelState.IsValid)
        {
            //return success result
        }
       
        return BadRequest(ModelState);
    }
