    public class ResultMessage<T> {
        public T Result { get; set; }
        public HttpStatusCode ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
    
    ResultMessage<T> GetResultMessage<T>(T value, HttpStatusCode resultCode) {
        return new ResultMessage<T> {
            Result = value,
            ResultCode = resultCode,
            ResultMessage = resultCode.ToString()
        };
    }
    
    [HttpGet]
    [Produces("application/json")]
    public IActionResult GetValues()
    {
        var toRet = new[] {"value1", "value2"};
        return Ok(GetResultMessage(toRet, HttpStatusCode.OK));
    }
