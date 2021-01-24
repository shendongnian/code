        [Route("somePost")]
        [HttpPost]
        public IHttpActionResult DoSomething(HttpRequestMessage request)
        {
            var str = request.Content.ReadAsStringAsync().Result;
            return Ok();
        }
