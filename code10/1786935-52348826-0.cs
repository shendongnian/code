      public class Upload
      {
        public string data { get; set; }
        public IFormFile file { get; set; }
      }
    [HttpPost]
    [Route("upload")]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult> _upload([FromForm] Upload o)
    {
      List<Field> x = JsonConvert.DeserializeObject<List<Field>>(o.data);
      return Ok();
    }
