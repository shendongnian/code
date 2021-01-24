    [HttpGet]
    public async Task<ActionResult<List<EntryDto>>> GetMany(long id) {
        //lets say we wanted to validate id
        if(id < 1) {
            return BadRequest("id must be greater than zero (0)");
        }
    
        var result = await _entryService.GetMany(id);
        if(result == null || result.Count == 0) {
            return NotFound(); // returns proper response code instead of null
        }
        return result;
    }
