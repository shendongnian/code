        [HttpGet("{param1}/{param2}")]
        public string MethodWithGet(string param1, string param2)
        {
           return interalgetmethodcall(param1, param2);
        }
    
        [HttpPost]
        public string MethodWithPost([FromBody]string param1, [FromBody]string param2,[FromBody] dynamic datafrombody)
        {
           return interalpostmethodcall(param1, param2, datafrombody.toString());
        }
