        [Route("Files/Upload/")]
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
            //Windows path
            var uploadLocation = Path.Combine(_env.WebRootPath, "Uploads\\UsersImg");
            //Linux path
            //var uploadLocation = Path.Combine(_env.WebRootPath, "Uploads//UsersImg");
            var fileName = file.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
            if (file.Length > 0)
                {
                    using (var stream = new FileStream(Path.Combine(uploadLocation, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            return Ok();
        }
