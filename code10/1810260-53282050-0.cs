        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]RequestAdd person)
        {
            if(person != null){
                return Ok("good");
            }
            return Ok("false");
        }
