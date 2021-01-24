        [[ActionName("MyMethod1")]
        [HttpGet]
        public IHttpActionResult MyMethod1(Guid id)
        {
            return Ok<string>($" ok MyMethod1 and id= {id}");
        }
       [ActionName("MyMethod2")]
        [HttpGet]
        public IHttpActionResult MyMethod2(Guid id)
        {
            return Ok<string>($" ok MyMethod2 and id= {id}");
        }
