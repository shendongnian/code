        [Produces("application/json")]
        [Route("api/audio")]
        [HttpPost]
        public async Task<IActionResult> ProcessCommandAsync([FromForm]IFormFile command)
        {  
            if(command.ContentType != "audio/wav" && command.ContentType != "audio/wave" || command.Length < 1)
            {
                return BadRequest();
            }
            var text = await CovnvertSpeechToTextApiCall(ConvertToByteArrayContent(command));
           
            return Ok(FormulateResponse(text));
        }
        
        private ByteArrayContent ConvertToByteArrayContent(IFormFile audofile)
        {
            byte[] data;
            using (var br = new BinaryReader(audofile.OpenReadStream()))
            {
                data = br.ReadBytes((int) audofile.OpenReadStream().Length);
            }
            return new ByteArrayContent(data);
        }
