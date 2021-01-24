    [HttpDelete]
    [Route("api/User/{id}")]
    [ResponseType(typeof(User))]
    public async Task<IHttpActionResult> DeleteUser(decimal id)
    {
        ...
    }
