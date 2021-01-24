            [HttpPost("SetKey")]
        public IActionResult SetKey([FromForm]string key,[FromForm]string value)
        {
            _errorProvider.AddOrUpdateError(key, value);
            return Ok();
        }
        [HttpPost("CustomAttribute")]
        public IActionResult CustomAttribute(InputModel input)
        {
            return Ok();
        }
