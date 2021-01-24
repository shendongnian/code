    public class ModelDTO
    {
        public string Id{get; set;}
        public List<string> Childs {get; set;}
    }
    [HttpPost]
    [Route("api/nice/Save")]
    public bool Save([FromBody] ModelDTO model)
    { ...
