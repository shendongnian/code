        [HttpPost]
        public async Task<IActionResult> UploadSingleFile([FromForm(Name = "file")] IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var IDsList = new IDsList();
            try
            {
                var id = SaveFile(file);
                IDsList.Files.Add(new IDsList.FileInfo() { id = id, fileName = file.FileName });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Content(JsonConvert.SerializeObject(IDsList), "application/json");
        }
        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadFiles([FromForm(Name = "files")] ICollection<IFormFile> files)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var files = Request.Form.Files?.GetFiles("files");
            String message = String.Empty;
            int filesCounter = 0;
            var IDsList = new IDsList();
            foreach (var file in files)
            {
                if (file.Length == 0)
                    message = message + $"errorDescription {file.FileName}\n";
                try
                {
                    var id = SaveFile(file);
                    IDsList.Files.Add(new IDsList.FileInfo() { id = id, fileName = file.FileName });
                    filesCounter++;
                }
                catch(Exception ex)
                {
                    message = $"{message}{ex.Message}\n";
                }
            }
            IDsList.message = $"Amount: {filesCounter}.\n{message}";
            return Content(JsonConvert.SerializeObject(IDsList), "application/json");
        }
