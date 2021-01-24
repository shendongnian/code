    [HttpGet]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Index([FromQuery] int offset = 0, [FromQuery] int limit = 25)
    {
        Paging paging = new Paging(offset, limit);
        return Ok(await _queryStore.GetAllMyModelQuery.Execute(paging).ConfigureAwait(false));
    }
