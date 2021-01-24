    //GET api/ControllerName?host/api/ControllerName?p1=1&p2=2&p3=3&p4=4&p5=5
    [HttpGet]
    [Route("")]
    public IHttpActionResult GetItemByNameAndId([FromUri(PreFix="")] ParamClass param) {
        //...
        return Ok(someResult);
    }
