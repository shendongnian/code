    [HttpPatch]
    [ActionName("Index")]
    [Authorize(Policy = "Model")]
    public async Task<JsonResult> Update([FromRoute]int id, int modelId, [FromBody]Device device)
to
    [HttpPatch("{id}")]
    [ActionName("Index")]
    [Authorize(Policy = "Model")]
    public async Task<JsonResult> Update([FromRoute]int id, int modelId, [FromBody]Device device)
(asp.net core 2.1)
