    [HttpPost("data/delete")]
    public async Task<IActionResult> DeleteData([FromBody] List<UserEntity> jsonData)
    {
        if (!ModelState.IsValid)
        {
            var error = ModelState.Values
                .SelectMany(x => x.Errors)
                .FirstOrDefault(x => x.Exception != null);
            return BadRequest(error != null 
                ? error.Exception.Message
                : "Error in JSON request");
         }
         // your regular processing code
    }
