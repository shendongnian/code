    [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm]IFormFile file)
        {
            var model = await _filesService.UploadFile(file);
            return Ok();
        }
