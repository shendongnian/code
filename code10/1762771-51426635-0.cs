    public class CustomParams
    {
        [FromQuery(Name = "foo")]
        public FooBar[] foo { get; set; }
    }
    public class FooBar
    {
        [FromQuery(Name = "[bar]")]
        public string bar { get; set; }
        [FromQuery(Name = "[id]")]
        public int id { get; set; }
    }
    // GET api/values
    [HttpGet]
    public ActionResult<CustomParams> Get([FromQuery]CustomParams args)
    {
        return args;
    }
