            [HttpPost]
            [Route("Upload")]
            public async Task<IActionResult> Upload(string targetIdStr, string feedType,
      string contentType, string dateCreated, string description, IFormFile file)
            {
                return Ok();
            }
