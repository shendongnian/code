    public class FooBar
    {
        [FromQuery(Name = "[bar]")]
        public string bar { get; set; }
        [FromQuery(Name = "[id]")]
        public int id { get; set; }
    }
    // GET api/values
    [HttpGet]
    public ActionResult<FooBar> Get([FromQuery(Name = "foo")]FooBar[] foo)
    {
        return foo;
    }
