    public class MyModelDto
    {
        public string Page { get; set; }
    }
    
    [Route("LogHit")]
    [HttpPost]
    public void LogHit([FromBody] MyModelDto Page)
    {
    }
