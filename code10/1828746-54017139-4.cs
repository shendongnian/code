        [ActionName("MyMethod1")]
        [HttpGet]
        public IHttpActionResult MyMethod1(Guid id)
        {
            return Ok<string>($" ok MyMethod1 and id= {id}");
        }
