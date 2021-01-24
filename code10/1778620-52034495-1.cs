    [HttpPost]
     // attention name of formfile must be equal to the key u have used for formdata    
    public async Task<IActionResult> UploadFileAsync([FromForm] IFormFile myFile)
    {
         var totalSize = myFile.Length;
         var fileBytes = new byte[myFile.Length];
    
         using (var fileStream = myFile.OpenReadStream())
         {
             var offset = 0;
    
             while (offset < myFile.Length)
             {
                 var chunkSize = totalSize - offset < 8192 ? (int) totalSize - offset : 8192;
    
                 offset += await fileStream.ReadAsync(fileBytes, offset, chunkSize);
             }
         }
       // now save the file on the filesystem
       StoreFileBytes("mypath", fileBytes);
       return Ok();
    }
