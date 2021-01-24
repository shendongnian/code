    [HttpPost]
    public async Task<IActionResult> Send([Bind("File")] MyViewModel myVM)
    {
       if (myVM.File?.Length > 0)
       {
                byte[] fileBytes;
                using (var fileStream = myVM.File.OpenReadStream())
                using (var ms = new MemoryStream())
                {
                    fileStream.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                
                var fileName = Path.GetFileName(myVM.File.FileName);
                var fileMimeType = myVM.File.ContentType;
                var fileContent = fileBytes;
              
                //You have all the file attributes and content
       }
    }
