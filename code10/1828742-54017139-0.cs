        [Route("MyMethod1/{id}")]
        [HttpGet]
        public IHttpActionResult MyMethod1(Guid id)
        {
            return Ok<string>($" ok MyMethod1 and id= {id}");
        }
        [Route("MyMethod2/{id}")]
        [HttpGet]
        public IHttpActionResult MyMethod2(Guid id)
        {
            return Ok<string>($" ok MyMethod2 and id= {id}");
        }
