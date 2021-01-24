    [HttpGet]
    [Route("api/tblProducts/{UserId}/CheckUserAvil")]
    [ResponseType(typeof(int))]
    public IHttpActionResult CheckUserAvil(string UserId) {
        int exist = db.CheckUserIdAvil(UserId);
        var model = new {
            Exist = exist
        };
        return Ok(model);
    }
