    [Route("User/{EntityId}/{StatusFilter}")] // api/User/{EntityId}/{StatusFilter}
    [HttpPut] 
    public IActionResult Put(int EntityId, int StatusFilter){
      // do stuff calling directly EntityId and StatusFilter
    }
