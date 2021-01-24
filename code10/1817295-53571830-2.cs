    [HttpPost]
    [Route("InsertData")]
    public async Task<IActionResult> InsertData([FromBody] Model model) {
        try {
            if(ModelState.IsValid) {
                _webHookDb.UserData.Add(new UserData() { 
                    FromAddress = model.FromAddress,
                    DateTime = DateTime.Now
                });
                await _webHookDb.SaveChangesAsync();
                return new Ok(model);
            }
            return BadRequest(ModelState); //Bad data?
        } catch (Exception ex) {
            return StatusCode(500, ex.Message); //Something wrong with my code?
        }
    }
