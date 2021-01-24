    [HttpPut]
    [Route("{id}")]
    [ResponseType(typeof(LocationViewModel))]
    public async Task<IHttpActionResult> PutLocation(Guid id, LocationViewModel location)
    {
    }
