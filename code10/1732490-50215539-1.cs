    public class CustomObject
    { 
        public string Name { get; set; }
        public string Email { get; set; }
    }
    [HttpGet]
    [Route("{foo.Name}/{foo.Email}")]
    public HttpResponseMessage Get([FromUri]CustomObject foo)
    {
       //...body
      return Request.CreateResponse(HttpStatus.OK, foo);
    } 
