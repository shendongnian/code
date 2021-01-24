    [HttpPost]
        [Route("lastsaledate")]
        public async Task<IHttpActionResult> GetLastSalesUpdate([FromBody]string identifier, [FromBody]bool endOfDay)
        {
            //do stuff
            return Ok(Result);
        }
