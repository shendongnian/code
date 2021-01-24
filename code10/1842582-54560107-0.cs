    [HttpPost]
    public IHttpActionResult Newemployee([FromBody] RequestManual items) {
        if(ModelState.IsValid) {
            var response = Service.Newemployee(items.Datos);
            return Ok(response);
        }
        return BadRequest(ModelState);
    }
