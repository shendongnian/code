        [ActionName("MyMethod2")]
        [HttpGet]
        public IHttpActionResult MyMethod2(Guid id)
        {
            return Ok<string>($" ok MyMethod2 and id= {id}");
        }
