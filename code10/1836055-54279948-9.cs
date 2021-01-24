    public class MyModelDto
    {
        public string Page { get; set; }
    }
    
    [Route("LogHit")]
    [HttpPost]
    public void LogHit([FromBody] MyModelDto model) // add FromBody here
    {
        // model.Page will contain "test"
    }
