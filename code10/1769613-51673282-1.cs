    class RequestModel{
    public string VarA {get;set;}
    public string VarB {get;set;}
    public string VarC {get;set;}
    }
    
        [HttpPut]
        [Route("server")]
        public async Task<IActionResult> DoSomething([FromBody] RequestModel request)
        {
        
        }
