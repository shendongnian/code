    [HttpPut]
    public async Task<IHttpActionResult> UpdateAsync(Update update)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // perform the update
        return StatusCode(HttpStatusCode.NoContent);
    }
