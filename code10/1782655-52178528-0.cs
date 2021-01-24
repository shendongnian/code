    [HttpPost("{className}/{methodName}")]
    public ActionResult<string> Post(string className, string methodName, [FromBody] Data body) {
        if(ModelState.IsValid) {
            int args = body.args
            //...
        }
        return BadRequest(ModelState);
    }
