        [HttpPost("api/image")]
        public IActionResult Post(IFormFile file)
        {
            var filePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
